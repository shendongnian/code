    static HashSet<string> frameWhiteList = new HashSet<string> { "www.domain.com",
                                                        "mysub.domain.tld",
                                                        "partner.domain.tld" };
        protected void EnforceFrameSecurity()
        {
            var framer = Request.UrlReferrer;
            string frameOptionsValue = "SAMEORIGIN";
            if (framer != null)
            {
                if (frameWhiteList.Contains(framer.Host))
                {
                    frameOptionsValue = string.Format("ALLOW-FROM {0}", framer.Host);
                }
            }
            if (string.IsNullOrEmpty(HttpContext.Current.Response.Headers["X-FRAME-OPTIONS"]))
            {
                HttpContext.Current.Response.AppendHeader("X-FRAME-OPTIONS", frameOptionsValue);
            }
        }
