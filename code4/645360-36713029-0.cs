    			//Do webrequest to get info on secure site
			var certName = "FileName";
			var url = "https://mail.google.com";
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			response.Close();
			//retrieve the ssl cert and assign it to an X509Certificate object
			X509Certificate cert = request.ServicePoint.Certificate;
			//convert the X509Certificate to an X509Certificate2 object by passing it into the constructor
			X509Certificate2 cert2 = new X509Certificate2(cert);
			string cn = cert2.GetIssuerName();
			string cedate = cert2.GetExpirationDateString();
			string cpub = cert2.GetPublicKeyString();
			var path = Directory.GetCurrentDirectory() + string.Concat("\\", certName, ".der");
			byte[] certData = cert2.Export(X509ContentType.Cert);
			File.WriteAllBytes(path, certData);
			Console.WriteLine("cert2.GetIssuerName :{0}", cert2.GetIssuerName());
			Console.WriteLine("cert2.GetExpirationDateString :{0}", cert2.GetExpirationDateString());
			Console.WriteLine("cert2.GetPublicKeyString :{0}", cert2.GetPublicKeyString());
			
