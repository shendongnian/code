    try
            {
                var pl= new payLoad(){ UserId = "9769595975",Passold = "qwert1",Passnew ="qwert2"};
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(payLoad));
                MemoryStream mem = new MemoryStream();
                //serializing payload
                ser.WriteObject(mem, pl);
                string pycontent = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                HttpContent pyContentPost = new System.Net.Http.StringContent(pycontent, Encoding.UTF8, "application/json");
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PutAsync(baseUrl+ "/profile/190/updateprofile", pyContentPost).Result;
                    var result = response.Content.ReadAsStringAsync().Result;
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new WebFaultException<string>("HttpException occured :",HttpStatusCode.InternalServerError);
                    }
                    return Convert.ToInt32(result);//return result 
                }
            }
            catch (HttpRequestException ex)
            {
                throw new WebFaultException<string>(string.Format("Service Exception occured : {0}", ex.Message), HttpStatusCode.BadRequest);
            }
