       var innerHtml = webBrowser1.SaveToString();
            var code = string.Empty;
            if (innerHtml.Contains("<code>"))
            {
                code = innerHtml.Substring(innerHtml.IndexOf("<code>") + 6, 7);
            }
            else if (innerHtml.Contains("oauth_pin"))
            {
                code = innerHtml.Substring(innerHtml.IndexOf("oauth_pin") + 10, 7);
            }
