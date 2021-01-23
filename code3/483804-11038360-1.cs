     public ActionResult GetEvent()
     {
            string at = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa";
            string et = "KI2XfwQNByLPFdK4i3a74slLT7sjjzYRi9RR7zEtCoQ%3D";
            string t = "20111128183020";
            string _checkingUrl = String.Format("http://172.22.22.10/SampleAPI/Event/GetEvents?at={0}&et={1}&t={2}&responseFormat=json", at, et, t);
            System.Net.HttpWebRequest request=System.Net.WebRequest.Create(_checkingUrl) as System.Net.HttpWebRequest;
            System.Net.HttpWebResponse response=request.GetResponse() as System.Net.HttpWebResponse;
            using (var readResponse= new StreamReader(response.GetResponseStream()))
            {
                 return Content(readResponse.ReadToEnd(), "application/json");
            }
    }
