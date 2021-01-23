    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Net;
    using System.Text;
    using System.IO;
    using System.Collections;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.Configuration;
    using System.Web.Script.Serialization;
    using PushNotification.Entities;
    namespace PushNotification
    {
        public class AndroidCommunicationService
        {
           
            public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            }
            
            public string GetAuthenticationCode()
            {
                string returnUrl = "";
                string URL = "https://accounts.google.com/o/oauth2/auth";
                NameValueCollection postFieldNameValue = new NameValueCollection();
                postFieldNameValue.Add("response_type", "code");
                postFieldNameValue.Add("scope", "https://android.apis.google.com/c2dm/send");
                postFieldNameValue.Add("client_id", ConfigurationManager.AppSettings["ClientId"].ToString());
                postFieldNameValue.Add("redirect_uri", "http://localhost:8080/TestServer/test");
                postFieldNameValue.Add("state", "profile");
                postFieldNameValue.Add("access_type", "offline");
                postFieldNameValue.Add("approval_prompt", "auto");
                postFieldNameValue.Add("additional_param", DateTime.Now.Ticks.ToString());
                string postData = GetPostStringFrom(postFieldNameValue);
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URL);
                Request.Method = "POST";
                Request.KeepAlive = false;
    
                Request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                Request.ContentLength = byteArray.Length;
    
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
                Stream dataStream = Request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
    
                Request.Method = "POST";
    
                try
                {
                    WebResponse Response = Request.GetResponse();
    
                    var sr = new StreamReader(Response.GetResponseStream());
                   // You can do this and return the content on the screen ( I am using MVC )
                    returnUrl = sr.ReadToEnd();
                  // Or 
                    returnUrl = Response.RedirectUri.ToString();
                }
                catch
                {
                    throw ;
                }
                return returnUrl;
            }
            public TokenResponse GetNewToken(string Code)
            {
                TokenResponse tokenResponse = new TokenResponse();
                string URL = ConfigurationManager.AppSettings["TokenCodeUrl"];
                NameValueCollection postFieldNameValue = new NameValueCollection();
                postFieldNameValue.Add("code", Code);
                postFieldNameValue.Add("client_id", ConfigurationManager.AppSettings["ClientId"]);
                postFieldNameValue.Add("client_secret", ConfigurationManager.AppSettings["ClientSecret"]);
                postFieldNameValue.Add("redirect_uri", ConfigurationManager.AppSettings["RedirectUrl"]);
                postFieldNameValue.Add("grant_type", "authorization_code");
    
                string postData = GetPostStringFrom(postFieldNameValue);
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URL);
                Request.Method = "POST";
                Request.KeepAlive = false;
                
                Request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                Request.ContentLength = byteArray.Length;
    
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
                Stream dataStream = Request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
               
                Request.Method = "POST";
                
                try
                {
                    WebResponse Response = Request.GetResponse();
                    var tokenStreamRead = new StreamReader(Response.GetResponseStream());
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var objText = tokenStreamRead.ReadToEnd();
                     tokenResponse = (TokenResponse)js.Deserialize(objText, typeof(TokenResponse));            
                }
                catch (WebException wex)
                {
                    var sr = new StreamReader(wex.Response.GetResponseStream());
                    
                    Exception ex = new WebException(sr.ReadToEnd() + wex.Message);
                    throw ex;
                }
                
                return tokenResponse;
            }
    
            public TokenResponse RefreshToken(string RefreshToken)
            {
                TokenResponse tokenResponse = new TokenResponse();
                string URL = ConfigurationManager.AppSettings["TokenCodeUrl"]; 
                NameValueCollection postFieldNameValue = new NameValueCollection();
                postFieldNameValue.Add("refresh_token", RefreshToken);
                postFieldNameValue.Add("client_id", ConfigurationManager.AppSettings["ClientId"]);
                postFieldNameValue.Add("client_secret", ConfigurationManager.AppSettings["ClientSecret"]);
                postFieldNameValue.Add("grant_type", "refresh_token");
    
                string postData = GetPostStringFrom(postFieldNameValue);
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URL);
                Request.Method = "POST";
                Request.KeepAlive = false;
    
                Request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                Request.ContentLength = byteArray.Length;
    
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
                Stream dataStream = Request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
    
                Request.Method = "POST";
    
                try
                {
                    WebResponse Response = Request.GetResponse();
                    var tokenStreamRead = new StreamReader(Response.GetResponseStream());
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var objText = tokenStreamRead.ReadToEnd();
                    tokenResponse = (TokenResponse)js.Deserialize(objText, typeof(TokenResponse));
                }
                catch 
                {
                    throw;
                }
    
                return tokenResponse;
            }
    
            public string SendPushMessage(string RegistrationId, string Message ,string AuthString)
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["PushMessageUrl"]);
                Request.Method = "POST";
                Request.KeepAlive = false;
    
                //-- Create Query String --//
                NameValueCollection postFieldNameValue = new NameValueCollection();
                postFieldNameValue.Add("registration_id", RegistrationId);
                postFieldNameValue.Add("collapse_key", "fav_Message");
                postFieldNameValue.Add("data.message", Message);
                postFieldNameValue.Add("additional_value", DateTime.Now.Ticks.ToString());
                
                string postData = GetPostStringFrom(postFieldNameValue);
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    
    
                Request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                Request.ContentLength = byteArray.Length;
    
    
    // This is to be sent as a header and not as a param .
                Request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + AuthString);
    
               
    
              
    
                try
                {
                    //-- Create Stream to Write Byte Array --// 
                    Stream dataStream = Request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                    ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
                    WebResponse Response = Request.GetResponse();
                    HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
    
                    if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
                    {
                        return "Unauthorized - need new token";
                    }
                    else if (!ResponseCode.Equals(HttpStatusCode.OK))
                    {
                        return "Response from web service isn't OK";
    
                    }
    
                    StreamReader Reader = new StreamReader(Response.GetResponseStream());
                    string responseLine = Reader.ReadLine();
                    Reader.Close();
    
                    return responseLine;
    
                }
                catch 
                {
                    
                    throw;
                }
               
              
            }
            
            private string GetPostStringFrom(NameValueCollection postFieldNameValue)
            {
                //throw new NotImplementedException();
                List<string> items = new List<string>();
    
                foreach (String name in postFieldNameValue)
                    items.Add(String.Concat(name, "=", System.Web.HttpUtility.UrlEncode(postFieldNameValue[name])));
    
                return String.Join("&", items.ToArray());
            }
            private static bool ValidateRemoteCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
            {
                return true;
            }
            
        }
    }
    public class TokenResponse
        {
            public String access_token{ get; set; }
    
            public String expires_in { get; set; }
    
            public String token_type { get; set; }
    
            public String refresh_token { get; set; }
    
        }
