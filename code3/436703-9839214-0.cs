    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Script.Serialization;
    namespace HarlequinShared
    {
	public class FacebookLogin
	{
		protected static string _appId = null;
		protected static string AppId
		{
			get
			{
				if (_appId == null)
					_appId = ConfigurationManager.AppSettings["FacebookAppId"] ?? null;
				return _appId;
			}
		}
		protected static string _appSecret = null;
		protected static string AppSecret
		{
			get
			{
				if (_appSecret == null)
					_appSecret = ConfigurationManager.AppSettings["FacebookAppSecret"] ?? null;
				return _appSecret;
			}
		}
		public static FacebookUser CheckLogin()
		{
			string fbsr = HttpContext.Current.Request.Cookies["fbsr_" + AppId].Value;
			int separator = fbsr.IndexOf(".");
			if (separator == -1)
			{
				return null;
			}
			string encodedSig = fbsr.Substring(0, separator);
			string payload = fbsr.Substring(separator + 1);
			string sig = Base64Decode(encodedSig);
			var serializer = new JavaScriptSerializer();
			Dictionary<string, string> data = serializer.Deserialize<Dictionary<string, string>>(Base64Decode(payload));
			if (data["algorithm"].ToUpper() != "HMAC-SHA256")
			{
				return null;
			}
			HMACSHA256 crypt = new HMACSHA256(Encoding.ASCII.GetBytes(AppSecret));
			crypt.ComputeHash(Encoding.UTF8.GetBytes(payload));
			string expectedSig = Encoding.UTF8.GetString(crypt.Hash);
			if (sig != expectedSig)
			{
				return null;
			}
			string accessTokenResponse = FileGetContents("https://graph.facebook.com/oauth/access_token?client_id=" + AppId + "&redirect_uri=&client_secret=" + AppSecret + "&code=" + data["code"]);
			NameValueCollection options = HttpUtility.ParseQueryString(accessTokenResponse);
				
			string userResponse = FileGetContents("https://graph.facebook.com/me?access_token=" + options["access_token"]);
			userResponse = Regex.Replace(userResponse, @"\\u([\dA-Fa-f]{4})", v => ((char)Convert.ToInt32(v.Groups[1].Value, 16)).ToString());
			FacebookUser user = new FacebookUser();
			Regex getValues = new Regex("(?<=\"email\":\")(.+?)(?=\")");
			Match infoMatch = getValues.Match(userResponse);
			user.Email = infoMatch.Value;
			getValues = new Regex("(?<=\"first_name\":\")(.+?)(?=\")");
			infoMatch = getValues.Match(userResponse);
			user.FirstName = infoMatch.Value;
			getValues = new Regex("(?<=\"last_name\":\")(.+?)(?=\")");
			infoMatch = getValues.Match(userResponse);
			user.LastName = infoMatch.Value;
			return user;
		}
		protected static string FileGetContents(string url)
		{
			string result;
			WebResponse response;
			WebRequest request = HttpWebRequest.Create(url);
			response = request.GetResponse();
			using (StreamReader sr = new StreamReader(response.GetResponseStream()))
			{
				result = sr.ReadToEnd();
				sr.Close();
			}
			return result;
		}
		protected static string Base64Decode(string input)
		{
			UTF8Encoding encoding = new UTF8Encoding();
			string encoded = input.Replace("=", string.Empty).Replace('-', '+').Replace('_', '/');
			var decoded = Convert.FromBase64String(encoded.PadRight(encoded.Length + (4 - encoded.Length % 4) % 4, '='));
			var result = encoding.GetString(decoded);
			return result;
		}
	}
	public class FacebookUser
	{
		public string UID { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
    }
