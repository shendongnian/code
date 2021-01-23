    private void Submit(object sender, EventArgs e)
            {
                string amountOffensiveUnits = "enter amount";
                string amountDeffensiveUnits = "enter amount";
                
                try
                {
                    //LoginScreen_webBrowser.Document.GetElementById("Offensive_txt_id").InnerText = User_Name_txt.Text;
                    //LoginScreen_webBrowser.Document.GetElementById("Deffensive_txt_id").InnerText = Password_txt.Text;
                    LoginScreen_webBrowser.Document.GetElementById("maxdeffence_button_id").InvokeMember("Click");
                    LoginScreen_webBrowser.Document.GetElementById("maxoffence_button_id").InvokeMember("Click");
                    
                    LoginScreen_webBrowser.Document.GetElementById("submit_button_id").InvokeMember("Click");
                 
                }
                catch (MissingFieldException exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }
