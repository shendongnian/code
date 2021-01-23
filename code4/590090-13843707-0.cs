        [HttpPost]
        public ActionResult SubmitToCris(NewApplicantViewModel model)
        {
            // Setup my variables
            string First = model.PersonModel.FirstName;
            string Last = model.PersonModel.LastName;
            string dob = model.PersonModel.DateofBirth.ToString("yyyy-MM-dd");
            string historyURL = "https://www.nunya.com/XMLServer/XMLServer.cgi";
            //Build my data to be sent in key/value pair string 
            string postData = "MaxRecords=0&UserID=skapi&Password=sk12024&Version=2.0&RequestType=searchName&FirstName="
                                        + First + "&LastName="
                                        + Last + "&DOB="
                                        + dob;
            //Create the web request, populate the header info
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(crisURL);
            request.Method = "POST";
            request.ContentLength = postData.Length;
            request.ContentType = "application/x-www-form-urlencoded";
 
            // Send it
            using (Stream writeStream = request.GetRequestStream())
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                writeStream.Write(byteArray, 0, byteArray.Length);
                writeStream.Close();
            }
            // Receive the response and do stuff with it.
            string result = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using( Stream responseStream = response.GetResponseStream() )
                {
                    using( StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        result = readStream.ReadToEnd();
                    }
                }
            }
            XDocument resultLoad = XDocument.Parse(result);
            ViewBag.XmlResponse = resultLoad.ToString();
            return View();
        }
