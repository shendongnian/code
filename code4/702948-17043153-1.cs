    private const string RECAPTCHA_CHALLENGE_FIELD = "recaptcha_challenge_field";
    private const string RECAPTCHA_RESPONSE_FIELD = "recaptcha_response_field";
    protected string RecaptchaPublicKey {
      get { return ConfigurationManager.AppSettings["RecaptchaPublicKey"]; }
    }
    protected void btnSubmit_Click(object sender, EventArgs e) {
      var validator = new Recaptcha.RecaptchaValidator {
        PrivateKey = ConfigurationManager.AppSettings["RecaptchaPrivateKey"],
        RemoteIP = Request.UserHostAddress,
        Challenge = Context.Request.Form[RECAPTCHA_CHALLENGE_FIELD],
        Response = Context.Request.Form[RECAPTCHA_RESPONSE_FIELD]        
      };
      if (validator.Validate().IsValid) {
        litResult.Text = "All Good";
      } else {
        litResult.Text = "The words you entered are incorrect";
      }
    }
