                string postUrl = "https://graph.facebook.com/me/feed";
            string postParameters;
                        
            postParameters = string.Format("message={0}&picture={1}&name={2}&caption={2}&description={3}&link={4}&access_token={5}",
                                                "[Message]",
                                                "[PictureUrl]",
                                                "[Name]",
                                                "[Caption]",
                                                "[Link]",
                                                accessToken);
            try
            {
                System.Net.WebRequest req = System.Net.WebRequest.Create(postUrl);
                req.ContentType = "application/x-www-form-urlencoded";
                req.Method = "POST";
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(postParameters);
                req.ContentLength = bytes.Length;
                using (System.IO.Stream os = req.GetRequestStream())
                {
                    os.Write(bytes, 0, bytes.Length); //Push it out there
                    os.Close();
                    using (WebResponse resp = req.GetResponse())
                    using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                    {
                        ViewBag.PostResult = sr.ReadToEnd().Trim();
                        sr.Close();
                    }
                    os.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error ocurred while posting data to the user's wall: " + postUrl + "?" + postParameters, ex);
            }
            return RedirectToAction(XXXXXXXXXXXxx....); //Then i redirect to another page.
