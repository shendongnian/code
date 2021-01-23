    protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
    
            if (IsPostBack)
            {
                var fCollection = (NameValueCollection)Request.GetType().GetField("_form", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(Request);
                PropertyInfo oReadable = fCollection.GetType().GetProperty("IsReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
                oReadable.SetValue(fCollection, false, null);
    
                foreach (string s in Request.Params.Keys)
                {
                    var pCtrl = Page.FindControl(s);
                    //Sanitize the posted values (TextHandler.SimpleSanitize is my own static method)
                    if (pCtrl != null) fCollection[s] = TextHandler.SimpleSanitize(fCollection[s]);
                }
    
                oReadable.SetValue(fCollection, true, null);
    
            }
        }
