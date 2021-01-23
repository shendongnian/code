    private SHDocVw.InternetExplorer TargetIE = null;
            string url;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                GetTheIEObjectFromSystem);
                SendTextToActiveElementWithSubmitOptionSet();
            }
            private void GetTheIEObjectFromSystem(
            {
                SHDocVw.ShellWindows SWs = new SHDocVw.ShellWindows();
                foreach (SHDocVw.InternetExplorer internetExplorer in SWs)
                {
                    url = internetExplorer.LocationURL;
                    TargetIE = internetExplorer;
                    return;
                }
    
            }
            private void SendTextToActiveElementWithSubmitOptionSet()
            {
                mshtml.IHTMLDocument2 document = null;
                document = TargetIE.Document as mshtml.IHTMLDocument2;
                if (!document.activeElement.isTextEdit)
                {
                    MessageBox.Show("Active element is not a text-input system");
                }
                else
                {
                    HTMLInputElement HTMLI;
                    HTMLI = document.activeElement as HTMLInputElement;
                    var tag = HTMLI.document as mshtml.HTMLDocumentClass;
                    mshtml.IHTMLElementCollection hTMLElementCollection = tag.getElementsByTagName("input");
                    //for (int i = 0; i < a.length; i++)
                    {
                        foreach (mshtml.HTMLInputElement el in hTMLElementCollection)
                        {
                            switch (el.id)
                            {
                                case "txtFirstName":
                                    el.value = textBox1.Text;
                                    break;
                                case "txtLastName":
                                    el.value = textBox2.Text;
                                    break;
                                case "txtAddress":
                                    el.value = textBox3.Text;
                                    break;
                                case "txtMobile":
                                    el.value = textBox4.Text;
                                    break;
                            }                        
                        }
                    }
    
    
                }
            }
