            private void button3_Click(object sender, EventArgs e)
        {
            CookieContainer cookieJar = new CookieContainer();
            User user = new User(textBox1.Text,maskedTextBox1.Text);
            string url = "http://"your-web-address"/"your-rest-service"/?q="your-resurce"/user/login.json";
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);          
                request.ContentType = "application/json";
                request.Method = "POST";
                request.CookieContainer = cookieJar;
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string query = JsonConvert.SerializeObject(user);
                    streamWriter.Write(query);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                }
		
		//Check to see if you're logged in
                url = "http://web-address/rest-server/?q=resurce/system/connect.json";
                var newRequest = (HttpWebRequest)WebRequest.Create(url);
                newRequest.CookieContainer = cookieJar;
                newRequest.ContentType = "application/json";
                newRequest.Method = "POST";
                
                var newResponse = (HttpWebResponse)newRequest.GetResponse();
                using (var newStreamReader = new StreamReader(newResponse.GetResponseStream()))
                {
                    var newResponseText = newStreamReader.ReadToEnd();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Can't access server");
            }
        }
  
