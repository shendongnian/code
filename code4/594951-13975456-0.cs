    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using Utilities.Sanitizers;
    namespace Services {
    public class LoginService : Page {
    protected HtmlInputControl username, password;
    public void Post_Form(object sender, EventArgs e) {
        if (username.Value != "" && password.Value != "") {
            //LOGIC HERE
            //This doesn't work
            //CustomSanitize a = new CustomSanitize();                              
        }
    }
    }
    }
    using System;
    namespace Utilities.Sanitizers
    {
    public class CustomSanitize {
        //instantiate here
        public string sanitizeUserPass() {
                return "logic here"
            }
    }
    }
