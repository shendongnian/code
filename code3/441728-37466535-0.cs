    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("URL");
    
                JArray array = new JArray();
                using (var twitpicResponse = (HttpWebResponse)request.GetResponse())
                {
    
                    using (var reader = new StreamReader(twitpicResponse.GetResponseStream()))
                    {
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        var objText = reader.ReadToEnd();
    
                        JObject joResponse = JObject.Parse(objText);
                        JObject result = (JObject)joResponse["result"];
                        array = (JArray)result["Detail"];
                        string statu = array[0]["dlrStat"].ToString();
                    }
    
                }
