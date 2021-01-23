    string requestBody = SerializeToString(requestObj);
    byte[] byteStr = Encoding.UTF8.GetBytes(requestBody);
    request.ContentLength = byteStr.Length;
    using (Stream stream = request.GetRequestStream())
    {
        stream.Write(byteStr, 0, byteStr.Length);
    }
    //Parse the response
    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
    {
        //Business error
        if (response.StatusCode != HttpStatusCode.OK)
        {
            Console.WriteLine(string.Format("Error: response status code is{0}, at time:{1}", response.StatusCode, DateTime.Now.ToString()));
            return "error";
        }
        else if (response.StatusCode == HttpStatusCode.OK)//Success
        {
            using (Stream respStream = response.GetResponseStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SubmitReportResponse));
                reportReq = serializer.Deserialize(respStream) as SubmitReportResponse;
            }
         }
    ...
