     public Form1()
            {
                InitializeComponent();
                //navigate to you destination 
                webBrowser1.Navigate("https://www.certiport.com/portal/SSL/Login.aspx");
            }
            bool is_sec_page = false;
            private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                if (!is_sec_page)
                {
                    //get page element with id
                    webBrowser1.Document.GetElementById("c_Username").InnerText = "username";
                    webBrowser1.Document.GetElementById("c_Password").InnerText = "pass";
                    //login in to account(fire a login button promagatelly)
                    webBrowser1.Document.GetElementById("c_LoginBtn_c_CommandBtn").InvokeMember("click");
                    is_sec_page = true;
                }
                //secound page(if correctly aotanticate
                else
                {
                    //intract with sec page elements with theire ids
                }
                
            }
