                HttpWebRequest webRequest = (HttpWebRequest)asynchronousResult.AsyncState;
                Stream postStream = webRequest.EndGetRequestStream(asynchronousResult);
                // creating JSON object
                JObject json =
                new JObject(new JProperty(VMConstants.JSON_CONSTANT_LOGINCMD, new JObject(
                new JProperty("employeeId", constant.EMPLID)
                )));
                JsonSerializer serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Ignore;
                using (StreamWriter sw = new StreamWriter(postStream))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    json.WriteTo(writer, null);
                }
                webRequest.BeginGetResponse(new AsyncCallback(GetResponseCallback), webRequest);
                       
                        // Start the web reponse
                postStream.Close();
