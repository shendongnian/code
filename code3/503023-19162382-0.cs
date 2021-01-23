        [AcceptVerbs(HttpVerbs.Post), ValidateInput(false)]
        public ActionResult LogOnPostAssertion(string openid_openidAuthData)
        {
            IAuthenticationResponse response;
            if (!string.IsNullOrEmpty(openid_openidAuthData))
            {
                var auth = new Uri(openid_openidAuthData);
                var headers = new WebHeaderCollection();
                foreach (string header in Request.Headers)
                {
                    headers[header] = Request.Headers[header];
                }
                // Always say it's a GET since the payload is all in the URL, even the large ones.
                HttpRequestInfo clientResponseInfo = new HttpRequestInfo("GET", auth, auth.PathAndQuery, headers, null);
                response = this.RelyingParty.GetResponse(clientResponseInfo);
            }
            else
            {
                response = this.RelyingParty.GetResponse();
            }
            if (response != null)
            {
                switch (response.Status)
                {
                    case AuthenticationStatus.Authenticated:
                        var token = RelyingPartyLogic.User.ProcessUserLogin(response);
                        this.FormsAuth.SignIn(token.ClaimedIdentifier, false);
                        string returnUrl = Request.Form["returnUrl"];
                        if (!String.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    case AuthenticationStatus.Canceled:
                        ModelState.AddModelError("OpenID", "It looks like you canceled login at your OpenID Provider.");
                        break;
                    case AuthenticationStatus.Failed:
                        ModelState.AddModelError("OpenID", response.Exception.Message);
                        break;
                }
            }
