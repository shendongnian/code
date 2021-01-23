                WebClient client = new WebClient();
                Stream stream = client.OpenRead("http://waps.repli-con.com/services/ivrservices/getUserNameRecording/10000");
                StreamReader reader = new StreamReader(stream);
    
                JToken token = JObject.Parse(reader.ReadToEnd().ToString());
    
                string base64string = token.SelectToken("result").SelectToken("value").ToString();
                Byte[] b = Convert.FromBase64String(base64string);
                System.IO.File.WriteAllBytes(@"C:\Users\user\Desktop\test.wav", b);   
                stream.Close();
