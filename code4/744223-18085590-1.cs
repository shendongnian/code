    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
        }
        private bool CheckUserPass(string username, string password) {
            // access DB or some other form of storage service
            return true;
        }
        protected void buttonLogin_Click(object sender, EventArgs e) {
            bool credentialsAreOk = this.CheckUserPass(
                this.textBoxUsername.Text,
                this.textBoxPassword.Text
            );
            if (credentialsAreOk) {
                this.Session["EMAIL_ADDRESS"] = "SomeEmail@SomeEmailProvider.com";
                this.Session["OTHER_INFORMATION_KEY"] = "Some other stuff which you have access to during the login process";
                this.Session["TIME_OF_LOGIN"] = DateTime.UtcNow;
                FormsAuthentication.RedirectFromLoginPage(this.textBoxUsername.Text, createPersistentCookie: false);
            }
        }
    }    
