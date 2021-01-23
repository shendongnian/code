    using System;
    using System.Web;
    using System.Text;
    namespace StackOverflow.Web.LoopThroughForm
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (IsPostBack)
                {
                    GetFormElements();
                }
            }
            private void GetFormElements()
            {
                // HttpContext object contains information of the current request, 
                // and the Form object contains all of the submitted form elements
                var form = HttpContext.Current.Request.Form;
                StringBuilder sb = new StringBuilder();
                string resultFormat = "<div>Element: {0} - Value: {1}";
                for (int i = 0; i < form.Count; i++)
                {
                    sb.AppendFormat(resultFormat, form.Keys[i], form[i]);
                }
                TestResultLabel.Text = sb.ToString();
            }
        }
    }
