    private   TextBox  gettextbox ()
        {
               System.Web.UI.Page Default = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
               ContentPlaceHolder cph = Default.Controls[0].FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
               TextBox Textbox1 = (TextBox)cph.FindControl("TextBox1");
               return Textbox1;
        }
