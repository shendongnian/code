        public class MultiLanguageUserControl : System.Web.UI.UserControl
        {
            public string getResValue(string id)
            {
                var ctrlPath = TemplateControl.AppRelativeVirtualPath;
                var ctrlFile = System.IO.Path.GetFileName(ctrlPath);
                var resObj = GetGlobalResourceObject(ctrlFile, id);
                if (resObj!=null)
                            return resObj.ToString();
                else
                            return string.Format("UNRESOLVED[{0}]", id);		
            }
        }
