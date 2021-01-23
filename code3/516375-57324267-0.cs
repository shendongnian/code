    static void Main(string[] args)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("Authorization", "Basic " + GetEncodedCredentials());
                string tasks = wc.DownloadString("yourjiraurl/search?jql=task=bug");
                var taskdetails = JsonConvert.DeserializeObject<TaskDetails>(tasks);
            }
        }
        static string GetEncodedCredentials()
        {
            string mergedCredentials = string.Format("{0}:{1}", "UserName", "Password");
            byte[] byteCredentials = UTF8Encoding.UTF8.GetBytes(mergedCredentials);
            return Convert.ToBase64String(byteCredentials);
        }
