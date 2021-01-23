    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Collections;
    using HtmlAgilityPack;
    using System.Data;
    namespace TestApp
    {
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void executeButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            TimeZone zone = TimeZone.CurrentTimeZone;
            TimeSpan offset = zone.GetUtcOffset(DateTime.Now);
            string email = "USERNAME";
            string password = "PASSWORD";
            List<string> URLList = new List<string>();
            foreach (string domain in Domains)
            {
                URLList.Add("https://admin.messaging.microsoft.com/TraceMessage.mvc/AsyncMessageList/123456?s=" + Uri.EscapeUriString(this.inputTB.Text) + "&r=" + domain + "&d=" + Uri.EscapeUriString(timeNow.AddDays(-29).ToString()) + "&e=" + Uri.EscapeUriString(timeNow.ToString()) + "&a=" + Uri.EscapeUriString(offset.Hours.ToString()));
            }
            var domainQueue = new Queue<string>(URLList);
            Action navigateQueue = () =>
            {
                if (domainQueue.Count != 0)
                {
                    this.wbControl.Navigate(domainQueue.Dequeue());
                }
                else
                {
                    MessageBox.Show("Completed");
                }
            };
            this.wbControl.LoadCompleted += (o, e0) =>
            {
                if (this.wbControl.IsLoaded == true)
                {
                    dynamic doc = this.wbControl.Document;
                    try
                    {
                        doc.GetElementById("email").SetAttribute("value", email);
                        doc.GetElementById("Password").SetAttribute("value", password);
                        doc.GetElementById("submit_signin").Click();
                    }
                    catch
                    {
                    }
                    if (e0.Uri.AbsolutePath.Contains("AsyncMessageList"))
                    {
                        List<string> DetailsList = new List<string>();
                        DetailsList.AddRange(ExtractAllAHrefTags(doc));
                        foreach (string href in DetailsList)
                        {
                            domainQueue.Enqueue(href);
                        }
                        navigateQueue();
                    }
                    if (e0.Uri.AbsolutePath.Contains("Details"))
                    {
                        resultsTB.Text += ParseEntries(doc);
                        navigateQueue();
                    }
                    
                }
            };
            navigateQueue();
        }
        private string ParseEntries(dynamic inputDoc)
        {
            HtmlAgilityPack.HtmlDocument docHAP = new HtmlAgilityPack.HtmlDocument();
            docHAP.LoadHtml(inputDoc.Body.InnerHtml.ToString());
            string csv = "";
            foreach (HtmlNode emNode in docHAP.DocumentNode.SelectNodes("//em"))
            {
                if (emNode.Attributes["class"] == null)
                {
                    csv += "\"" + emNode.InnerText.ToString() + "\",";
                }
            }
            csv = csv.Remove(csv.Length - 1, 1) + "\"" + Environment.NewLine;
            return csv;
        }
        private List<string> ExtractAllAHrefTags(dynamic inputDoc)
        {
            HtmlAgilityPack.HtmlDocument docHAP = new HtmlAgilityPack.HtmlDocument();
            docHAP.LoadHtml(inputDoc.Body.InnerHtml.ToString());
            List<string> hrefTags = new List<string>();
            try
            {
                foreach (HtmlNode link in docHAP.DocumentNode.SelectNodes("//a[@href]"))
                {
                    HtmlAttribute att = link.Attributes["href"];
                    hrefTags.Add("https://" + this.wbControl.Source.Host.ToString() + System.Web.HttpUtility.HtmlDecode(att.Value));
                }
            }
            catch
            {
            }
            return hrefTags;
        }
        private List<string> Domains
        {
            get
            {
                List<string> currentDomains = new List<string>();
                currentDomains.Add("example.com");
                currentDomains.Add("sub.example.com");
                currentDomains.Add("it.example.com");
                return currentDomains;
            }
        }
    }
    }
