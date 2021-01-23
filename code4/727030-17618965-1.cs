    List<string> ListOfStuff = new List<string>();
    foreach (Control item in ul_myLst.Controls)
    {
       if (item is System.Web.UI.HtmlControls.HtmlGenericControl)
            {
               ListOfStuff.Add(((System.Web.UI.HtmlControls.HtmlGenericControl)item).InnerHtml); 
            }
    }
