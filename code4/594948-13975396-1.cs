    namespace MyProject {
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
