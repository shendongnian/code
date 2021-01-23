        public void myDownloadfile(string token, string fileid, string platform)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("Token", token);
            parameters.Add("fileid", fileid);
            parameters.Add("plateform", platform);
            string url;
            url = "https://formbase.formmobi.com/dvuapi/downloadfile.aspx?" + "token=" + token + "&fileid=" + fileid + "&platform=" + platform;
            System.Net.WebClient wc = new System.Net.WebClient()
            wc.DownloadFile(url, "C:\\myFile.ext")
        }
