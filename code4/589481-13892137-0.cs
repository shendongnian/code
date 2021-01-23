        public void WriteError(string errorTask, string errorMessage)
                {
                    string task = "Error Log Entry";
                    string fileName = "";
                    string fileTitle = "";
                    string fileType = "";
        
                        using (SPSite oSiteCollection = new SPSite(SPContext.Current.Web.Url))
                        {
                            using (SPWeb oWebsite = oSiteCollection.RootWeb)
                            {                           
                                oWebsite.AllowUnsafeUpdates = true;               
            
                                SPSite errorLogSite = new SPSite(oWebsite.ServerRelativeUrl);
                                SPListItemCollection oList = errorLogSite.RootWeb.Lists["ErrorLog"].Items;
        
                                SPListItem oItem = oList.Add();
                                oItem["ErrorTask"] = task + ": " + errorTask;
                                oItem["ErrorMessage"] = errorMessage;
                                oItem["UserName"] = String.IsNullOrEmpty(UserName) ? "Not Available" : UserName;
                                oItem["FileName"] = String.IsNullOrEmpty(fileName) ? "Not Available" : fileName;
                                oItem["Title"] = String.IsNullOrEmpty(fileTitle) ? "Not Available" : fileTitle;
                                oItem["FileType"] = String.IsNullOrEmpty(fileType) ? "Not Available" : fileType;
        
                                oItem.Update();
                                oWebsite.Update();
                                oWebsite.AllowUnsafeUpdates = false;
                            }
                        }
        
                }
