        public ExtDeskResponse Post(MyAuth req) {
            //Captcha Validation
            var valid = req.Captcha == base.Session.Get<Captcha>("Captcha").result;
            //SS Authentication
            var authService = AppHostBase.Instance.TryResolve<AuthService>();
            authService.RequestContext = new HttpRequestContext(
                System.Web.HttpContext.Current.Request.ToRequest(),
                System.Web.HttpContext.Current.Response.ToResponse(),
                null);
            var auth = string.IsNullOrWhiteSpace(
                authService.Authenticate(new Auth {
                    UserName = req.UserName,
                    Password = req.Password,
                    RememberMe = req.RememberMe,   
                }).UserName);
            if (valid && auth) { 
                //...logic
            }
            return new MyAuthResponse() {
                //...data
            }; 
        }
