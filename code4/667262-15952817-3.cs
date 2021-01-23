            line = System.Web.HttpUtility.HtmlDecode(line);
            q = System.Web.HttpUtility.HtmlDecode(q);
            if (line.Contains(q)) {
                // do something
            }
