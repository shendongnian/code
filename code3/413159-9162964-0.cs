     public class NoCache : ActionFilterAttribute
    {
       
    public class CaptchaValidatorAttribute : ActionFilterAttribute
    {
        private const string CHALLENGE_FIELD_KEY = "recaptcha_challenge_field";
        private const string RESPONSE_FIELD_KEY = "recaptcha_response_field";
        private const string CAPTCHA_MODEL_KEY = "Captcha";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var captchaChallengeValue = filterContext.HttpContext.Request.Form[CHALLENGE_FIELD_KEY];
            var captchaResponseValue = filterContext.HttpContext.Request.Form[RESPONSE_FIELD_KEY];
            var captchaValidtor = new Recaptcha.RecaptchaValidator
            {
                PrivateKey = "key",
                RemoteIP = filterContext.HttpContext.Request.UserHostAddress,
                Challenge = captchaChallengeValue,
                Response = captchaResponseValue
            };
            var recaptchaResponse = captchaValidtor.Validate();
            if (!recaptchaResponse.IsValid)
            {
                filterContext.Controller
                    .ViewData.ModelState
                    .AddModelError(
                        CAPTCHA_MODEL_KEY,
                        "Entered text is invalid");
            }
            base.OnActionExecuting(filterContext);
        }
    }
    public static class CaptchaExtensions
    {
        public static string GenerateCaptcha(this HtmlHelper helper)
        {
            var captchaControl = new Recaptcha.RecaptchaControl
            {
                ID = "recaptcha",
                Theme = "white",
                PublicKey = "key",
                PrivateKey = "key"
            };
            var htmlWriter = new HtmlTextWriter(new StringWriter());
            captchaControl.RenderControl(htmlWriter);
            return htmlWriter.InnerWriter.ToString();
        }
    }
