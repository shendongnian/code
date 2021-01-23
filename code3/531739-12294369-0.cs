    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms;
    using System.Net;
    using System.IO;
    using System.Web;
    namespace BodytelConnection{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            webBrowser1.Navigate("http://www.bodytel.com/");
        }
        private void textBox_benutzername_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void textBox_passwort_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string benutzername = textBox_benutzername.ToString();
            string passwort = textBox_passwort.ToString();
            string cookieHeader;
            passwort = changeString(passwort);
            benutzername = changeString(benutzername);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://secure.bodytel.com/de/mybodytel.html");
            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;
            request.Method = "POST";
            string postData = "login=hans-neo@web.de&password=xxxxx&step=login";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string Text = "";
            
            foreach (Cookie cook in response.Cookies)
            {
                Text += "COOKIE: " + cook.Name + " = " + cook.Value + "\r\n";
            }
            request.AllowAutoRedirect = false;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            webBrowser1.Navigate("https://secure.bodytel.com/de/mybodytel.html");
        }
        private string changeString(string myString)
        {
            myString = myString.Replace("System.Windows.Controls.TextBox: ", "");
            return myString;
        }
    }
    }
