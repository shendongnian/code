    public static class AdsenseHelper
    {
        public static MvcHtmlString Adsense(this HtmlHelper htmlHelper, string clientKey, string adSlot)
        {
            var context = htmlHelper.ViewContext.HttpContext;
            var request = context.Request;
            int googleTime = (DateTime.Now - new DateTime(1970, 1, 1)).Days;
            var googleDt = (1000 * googleTime) + Math.Round(1000d * (DateTime.Now - DateTime.Today).Milliseconds);
            var googleUserAgent = context.Server.UrlEncode(request.ServerVariables["HTTP_USER_AGENT"]);
            var googleScheme = (string.Compare(request.ServerVariables["HTTPS"], "on") == 0) ? "https://" : "http://";
            var googleAdUrl =
                "http://pagead2.googlesyndication.com/pagead/ads?" +
                "client=" + clientKey + // ca-mb-pub-0000000000000000
                "&dt=" + googleDt +
                "&ip=" + context.Server.UrlEncode(request.ServerVariables["REMOTE_ADDR"]) +
                "&markup=xhtml" +
                "&output=xhtml" +
                "&ref=" + context.Server.UrlEncode(request.ServerVariables["HTTP_REFERER"]) +
                "&slotname=" + adSlot + // 0000000000
                "&url=" + context.Server.UrlEncode(googleScheme + request.ServerVariables["HTTP_HOST"] + request.ServerVariables["URL"]) +
                "&useragent=" + googleUserAgent +
                GoogleScreenRes(context.Request) +
                GoogleMuid(context.Request) +
                GoogleViaAndAccept(context, googleUserAgent);
            using (var client = new System.Net.WebClient())
            {
                string result = client.DownloadString(googleAdUrl);
                return new MvcHtmlString(result);
            }
        }
        private static string GoogleColor(string value, int random)
        {
            var colorArray = value.Split(',');
            return colorArray[random % (colorArray.Length)];
        }
        private static string GoogleScreenRes(HttpRequestBase request)
        {
            var screenRes = request.ServerVariables["HTTP_UA_PIXELS"];
            char delimiter = 'x';
            if (string.IsNullOrEmpty(screenRes))
            {
                screenRes = request.ServerVariables["HTTP_X_UP_DEVCAP_SCREENPIXELS"];
                delimiter = ',';
            }
            if (string.IsNullOrEmpty(screenRes))
            {
                screenRes = request.ServerVariables["HTTP_X_JPHONE_DISPLAY"];
                delimiter = '*';
            }
            if (screenRes != null)
            {
                string[] resArray = screenRes.Split(new[] { delimiter }, 2);
                if (resArray.Length == 2)
                {
                    return "&u_w=" + resArray[0] + "&u_h=" + resArray[1];
                }
            }
            return string.Empty;
        }
        private static string GoogleMuid(HttpRequestBase request)
        {
            var muid = request.ServerVariables["HTTP_X_DCMGUID"];
            if (!string.IsNullOrEmpty(muid))
            {
                return "&muid=" + muid;
            }
            muid = request.ServerVariables["HTTP_X_UP_SUBNO"];
            if (!string.IsNullOrEmpty(muid))
            {
                return "&muid=" + muid;
            }
            muid = request.ServerVariables["HTTP_X_JPHONE_UID"];
            if (!string.IsNullOrEmpty(muid))
            {
                return "&muid=" + muid;
            }
            muid = request.ServerVariables["HTTP_X_EM_UID"];
            if (!string.IsNullOrEmpty(muid))
            {
                return "&muid=" + muid;
            }
            return string.Empty;
        }
        private static string GoogleViaAndAccept(HttpContextBase context, string googleUserAgent)
        {
            if (string.IsNullOrEmpty(googleUserAgent))
                return string.Empty;
            string googleViaAndAccept = string.Empty;
            var via = context.Server.UrlEncode(context.Request.ServerVariables["HTTP_VIA"]);
            if (!string.IsNullOrEmpty(via))
            {
                googleViaAndAccept = "&via=" + via;
            }
            var accept = context.Server.UrlEncode(context.Request.ServerVariables["HTTP_ACCEPT"]);
            if (!string.IsNullOrEmpty(accept))
            {
                googleViaAndAccept = googleViaAndAccept + "&accept=" + accept;
            }
            return googleViaAndAccept;
        }
    }
