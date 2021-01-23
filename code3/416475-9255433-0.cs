    <%@ Page Language="C#" uiculture="auto" %>
    <%@ Import Namespace="System.Threading" %>
    <%@ Import Namespace="System.Globalization" %>
    <script runat="server">
    
        protected override void InitializeCulture()
        {
            if (Request.Form["ListBox1"] != null)
            {
                String selectedLanguage = Request.Form["ListBox1"];
                UICulture = selectedLanguage ;
                Culture = selectedLanguage ;
        
                Thread.CurrentThread.CurrentCulture = 
                    CultureInfo.CreateSpecificCulture(selectedLanguage);
                Thread.CurrentThread.CurrentUICulture = new 
                    CultureInfo(selectedLanguage);
            }
            base.InitializeCulture();
        }
    </script>
