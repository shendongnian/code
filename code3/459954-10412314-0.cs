    using System;
    using System.Windows.Forms;
    
    Namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            Public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                textBox1.Clear();
                GetFormulas();
                MessageBox.Show("Done!");
            }
    
            public void GetFormulas()
            {
                mshtml.HTMLDocument doc = NewHtmlDoc("http://office.microsoft.com/client/helppreview.aspx?AssetId=HV805551279990&lcid=1033&NS=EXCEL.DEV&Version=12&pid=CH080555125");
                mshtml.IHTMLElement2 table = (mshtml.IHTMLElement2)(mshtml.IHTMLElement2)((mshtml.IHTMLElement2)doc.getElementById("vstable")).getElementsByTagName("table").item(null, 0);
                mshtml.IHTMLElementCollection links = table.getElementsByTagName("A");
                foreach (mshtml.IHTMLElement link in links)
                {
                    mshtml.HTMLDocument doc2 = NewHtmlDoc(link.getAttribute("href",0).ToString());
                    mshtml.IHTMLElement div2 = doc2.getElementById("m_article");
                    foreach (mshtml.IHTMLElement elem in ((mshtml.IHTMLElement2)div2).getElementsByTagName("P"))
                    {
                        if (elem.getAttribute("className",0) != null && elem.getAttribute("className",0).ToString() == "signature")
                        {
                            string formulaString = elem.innerText;
                            textBox1.AppendText(link.innerText + "\t\t" + formulaString + "\n");
                        }
                    }
                }
            }
    
            private mshtml.HTMLDocument NewHtmlDoc(string url)
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                string page = wc.DownloadString(url);
                mshtml.IHTMLDocument2 doc = (mshtml.IHTMLDocument2)(new mshtml.HTMLDocument());
                doc.write(page);
                doc.close();
                return (mshtml.HTMLDocument)doc;
            }
    
        }
    }
    
