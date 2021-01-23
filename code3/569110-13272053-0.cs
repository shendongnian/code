            object o = null;
            InternetExplorer ie = new InternetExplorerClass();
            IWebBrowserApp wb = ie;
            wb.Visible = chkShowBrowser.Checked;
            wb.Navigate("http://LoginPage.aspx", ref o, ref o, ref o, ref o);
            do
            {
                Thread.Sleep(10000);
            } while (wb.Busy);
            if (ie.Document != null)
            {
                var myDoc = ie.Document as HTMLDocument;
                if (myDoc != null)
                {
                    var oUserName = (HTMLInputTextElement)myDoc.getElementById("ctl00_MainBodyPlaceholder_PublicPortalLogin_UserName");
                    oUserName.value = ConfigurationManager.AppSettings.Get("userName");
                    var oPassword =
                        (HTMLInputTextElement)
                        myDoc.getElementById("ctl00_MainBodyPlaceholder_PublicPortalLogin_Password");
                    oPassword.value = ConfigurationManager.AppSettings.Get("password");
                    var btnSubmitLogin =
                        (HTMLInputElement)myDoc.getElementById("ctl00_MainBodyPlaceholder_PublicPortalLogin_Login");
                    btnSubmitLogin.click();
                    do
                    {
                        Thread.Sleep(10000);
                    } while (wb.Busy);
                    if (ie.Document != null)
                    {
                        wb.Navigate("http://SearchPage.aspx", ref o, ref o, ref o, ref o);
                        do
                        {
                            Thread.Sleep(10000);
                        } while (wb.Busy);
                        if (ie.Document != null)
                        {
                            var oIncidentNumber =
                                (HTMLInputTextElement)
                                myDoc.getElementById("ctl00_MainBodyPlaceholder_txtIncidentNumber");
                            oIncidentNumber.value = ConfigurationManager.AppSettings.Get("incidentNumber");
                            var btnTicketNumberSearch =
                                (HTMLInputElement)myDoc.getElementById("ctl00_MainBodyPlaceholder_btnSearch");
                            btnTicketNumberSearch.click();
                            do
                            {
                                Thread.Sleep(10000);
                            } while (wb.Busy);
                            HTMLTable searchResultTable = myDoc.getElementById("ctl00_MainBodyPlaceholder_gdView_DXMainTable") as HTMLTable;
                           
                            
                            
                            if (searchResultTable != null)
                            {
                                //foreach (var VARIABLE in searchResultTable.T)
                                //{
                                    
                                //}
                            }
                            if (chkRenderBody.Checked)
                            {
                                txtFinalTextBox.Text = myDoc.body.outerHTML;
                            }
                        }
                    }
                }
            }
        
 
