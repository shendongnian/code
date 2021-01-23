        public static Image DownloadReCaptcha(string key, ref string challenge)
        {
            try
            {
                WebClient client = new WebClient();
                string response = client.DownloadString(string.Format("http://api.recaptcha.net/challenge?k={0}", key));
                Match match = Regex.Match(response, "challenge : '(.+?)'");
                if (match.Captures.Count == 0)
                {
                    challenge = null;
                    return null;
                }
                challenge = match.Groups[1].Value;
                if (File.Exists("captcha.jpg")) File.Delete("captcha.jpg");
                client.DownloadFile(string.Format("http://www.google.com/recaptcha/api/image?c={0}", challenge),
                                    "captcha.jpg");
                return Image.FromFile("captcha.jpg");
            }
            catch (Exception)
            {
                challenge = null;
                return null;
            }
        }
