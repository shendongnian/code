		public void Tweet(Action<string> response, string message)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat ("status={0}", PercentEncode(message));
			string content = sb.ToString();
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_postUrl);
			request.Headers.Add("Authorization", AuthorizeRequest(_accessToken, _accessTokenSecret, "POST", new Uri(_postUrl), content));
			request.ContentType = "application/x-www-form-urlencoded";
			request.ServicePoint.Expect100Continue = false;
			request.Method = "POST";
			try
			{
				try
				{
					using (Stream stream = request.GetRequestStream())
					{
						Byte[] streamContent = Encoding.UTF8.GetBytes("status=" + PercentEncode(message));
						stream.Write(streamContent, 0, streamContent.Length);
					}
					HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
					string contents = "";
					using (Stream stream = webResponse.GetResponseStream())
						using (StreamReader reader = new StreamReader(stream))
						{
							contents = reader.ReadToEnd();
						}
					Console.WriteLine("Twitter response: " + contents);
					response(DefaultSuccessMessage());
				}
				catch (WebException e)
				{
					Log.Info("TwitterService->Tweet web error: " + e.Message);
					response(DefaultErrorMessage());
				}
				catch (Exception e)
				{
					// Can happen if we had already favorited this status
					Log.Info("TwitterService->Tweet error: " + e.Message);
					response(DefaultErrorMessage());
				}
			}
			catch (WebException e)
			{
				Log.Info("TwitterService->Tweet web error 2: " + e.Message);
				response(DefaultErrorMessage());
			}
			catch (Exception e)
			{
				Log.Info("TwitterService->Tweet error 2: " + e.Message);
				response(DefaultErrorMessage());
			}
		}
		private string AuthorizeRequest(string oauthToken, string oauthTokenSecret, string method, Uri uri, string data)
		{
			string oauthNonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
			var headers = new Dictionary<string, string>()
			{
				{ "oauth_consumer_key", _oAuthConfig.ConsumerKey },
				{ "oauth_nonce", oauthNonce },
				{ "oauth_signature_method", "HMAC-SHA1" },
				{ "oauth_timestamp", MakeTimestamp() },
				{ "oauth_token", oauthToken },
				{ "oauth_verifier", PercentEncode(_authorizationVerifier) },
				{ "oauth_version", "1.0A" }
			};
			var signatureHeaders = new Dictionary<string,string>(headers);
			// Add the data and URL query string to the copy of the headers for computing the signature
			if (data != null && data != "")
			{
				var parsed = HttpUtility.ParseQueryString(data);
				foreach (string k in parsed.Keys)
				{
					signatureHeaders.Add(k, PercentEncode(parsed [k]));
				}
			}
			
			var nvc = HttpUtility.ParseQueryString(uri.Query);
			foreach (string key in nvc)
			{
				if (key != null)
					signatureHeaders.Add(key, PercentEncode(nvc [key]));
			}
			
			string signature = MakeSignature (method, uri.GetLeftPart(UriPartial.Path), signatureHeaders);
			string compositeSigningKey = MakeSigningKey(_oAuthConfig.ConsumerSecret, oauthTokenSecret);
			string oauth_signature = MakeOAuthSignature(compositeSigningKey, signature);
			headers.Add ("oauth_signature", PercentEncode(oauth_signature));
			return HeadersToOAuth(headers);
		}
		private static string PercentEncode (string s)
		{
			var sb = new StringBuilder ();
				
			foreach (byte c in Encoding.UTF8.GetBytes (s))
			{
				if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') || c == '-' || c == '_' || c == '.' || c == '~')
					sb.Append ((char) c);
				else
				{
					sb.AppendFormat ("%{0:X2}", c);
				}
			}
			return sb.ToString ();
		}
		private static string MakeTimestamp ()
		{
			return ((long) (DateTime.UtcNow - _unixBaseTime).TotalSeconds).ToString ();
		}
		private static string MakeSignature (string method, string base_uri, Dictionary<string,string> headers)
		{
			var items = from k in headers.Keys orderby k 
				select k + "%3D" + PercentEncode (headers [k]);
			return method + "&" + PercentEncode (base_uri) + "&" + 
				string.Join ("%26", items.ToArray ());
		}
		
		private static string MakeSigningKey (string consumerSecret, string oauthTokenSecret)
		{
			return PercentEncode (consumerSecret) + "&" + (oauthTokenSecret != null ? PercentEncode (oauthTokenSecret) : "");
		}
		
		private static string MakeOAuthSignature (string compositeSigningKey, string signatureBase)
		{
			var sha1 = new HMACSHA1 (Encoding.UTF8.GetBytes (compositeSigningKey));
			
			return Convert.ToBase64String (sha1.ComputeHash (Encoding.UTF8.GetBytes (signatureBase)));
		}
		private static string HeadersToOAuth (Dictionary<string,string> headers)
		{
			return "OAuth " + String.Join (",", (from x in headers.Keys select String.Format ("{0}=\"{1}\"", x, headers [x])).ToArray ());
		}
