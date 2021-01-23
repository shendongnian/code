        public static string SendEmail(string to, string subject, string bodyText, string bodyHtml, string from, string fromName)
        {
            WebClient client = new WebClient();
            NameValueCollection values = new NameValueCollection();
            values.Add("username", USERNAME);
            values.Add("api_key", API_KEY);
            values.Add("from", from);
            values.Add("from_name", fromName);
            values.Add("subject", subject);
            if (bodyHtml != null)
                values.Add("body_html", bodyHtml);
            if (bodyText != null)
                values.Add("body_text", bodyText);
            values.Add("to", to);
            byte[] response = client.UploadValues("https://api.elasticemail.com/mailer/send", values);
            return Encoding.UTF8.GetString(response);
        }
