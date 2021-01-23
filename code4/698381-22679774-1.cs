          string _auth = string.Format("{0}:{1}", "username", "password");
          string _enc = Convert.ToBase64String(Encoding.UTF8.GetBytes(_auth));
          string _basic = string.Format("{0} {1}", "Basic", _enc);
          HttpClient client = new HttpClient();
          client.DefaultRequestHeaders.Add("Authorization",_basic);
