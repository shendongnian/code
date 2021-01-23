    public void WriteError(string errorTask, string errorMessage)
            {
                string task = "Error Log Entry";
                string fileName = "";
                string fileTitle = "";
                string fileType = "";
    
                var errorLogWeb = SPContext.Current.Site.RootWeb;
                errorLogWeb.AllowUnsafeUpdates = true;
                var errorLogList = errorLogWeb.Lists["ErrorLog"];
                SPListItem oItem = errorLogList.Items.Add();
                oItem["ErrorTask"] = task + ": " + errorTask;
                oItem["ErrorMessage"] = errorMessage;
                oItem["UserName"] = String.IsNullOrEmpty(UserName) ? "Not Available" : UserName;
                oItem["FileName"] = String.IsNullOrEmpty(fileName) ? "Not Available" : fileName;
                oItem["Title"] = String.IsNullOrEmpty(fileTitle) ? "Not Available" : fileTitle;
                oItem["FileType"] = String.IsNullOrEmpty(fileType) ? "Not Available" : fileType;
    
                oItem.Update();
            }
