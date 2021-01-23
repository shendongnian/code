    public ActionResult CallAPIPut(string ApiUrl, string JsonString)
    {
        using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            byte[] data = Encoding.Default.GetBytes(JsonString);
            byte[] result = client.UploadData(ApiUrl, "PUT", data);
            return Content(Encoding.Default.GetString(result), "application/json");
        }
    }
