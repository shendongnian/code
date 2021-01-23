    public partial class Start : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // You generate your captcha somehow 
            string captchaString = "E F G 6 7";
            // Let's store the captcha in a place so that our wave generator can find it.
            Session.Add("captcha", captchaString);
            // Display the captcha in the page (this should actually be a blurry non-human readable image)
            lblCaptchaText.InnerText = captchaString;
        }
    }
