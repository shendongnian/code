     using System;
        using System.Linq;
        using System.Collections.Generic;
        using System.Collections.Specialized;
        using System.Web.Script.Serialization;
        using System.Net;
        using System.Text;
        using Google.Apis.Analytics.v3;
        using Google.Apis.Analytics.v3.Data;
        using Google.Apis.Services;
        using System.Security.Cryptography.X509Certificates;
        using Google.Apis.Auth.OAuth2;
        using Google.Apis.Util;
        using DotNetOpenAuth.OAuth2;
        using System.Security.Cryptography;
    
        namespace googleAnalytics
        {
            public partial class api : System.Web.UI.Page
            {
                public const string SCOPE_ANALYTICS_READONLY = "https://www.googleapis.com/auth/analytics.readonly";
        
                string ServiceAccountUser = "googleanalytics@googleanalytics.iam.gserviceaccount.com"; //service account email ID
                string keyFile = @"D:\key.p12"; //file link to downloaded key with p12 extension
                protected void Page_Load(object sender, EventArgs e)
                {
        
                   string Token = Convert.ToString(GetAccessToken(ServiceAccountUser, keyFile, SCOPE_ANALYTICS_READONLY));
        
                   accessToken.Value = Token;
        
                    var certificate = new X509Certificate2(keyFile, "notasecret", X509KeyStorageFlags.Exportable);
        
                    var credentials = new ServiceAccountCredential(
        
                        new ServiceAccountCredential.Initializer(ServiceAccountUser)
                        {
                            Scopes = new[] { AnalyticsService.Scope.AnalyticsReadonly }
                        }.FromCertificate(certificate));
        
                    var service = new AnalyticsService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credentials,
                        ApplicationName = "Google Analytics API"
                    });
        
                    string profileId = "ga:53861036";
                    string startDate = "2016-04-01";
                    string endDate = "2016-04-30";
                    string metrics = "ga:sessions,ga:users,ga:pageviews,ga:bounceRate,ga:visits";
        
                    DataResource.GaResource.GetRequest request = service.Data.Ga.Get(profileId, startDate, endDate, metrics);
        
        
                    GaData data = request.Execute();
                    List<string> ColumnName = new List<string>();
                    foreach (var h in data.ColumnHeaders)
                    {
                        ColumnName.Add(h.Name);
                    }
        
        
                    List<double> values = new List<double>();
                    foreach (var row in data.Rows)
                    {
                        foreach (var item in row)
                        {
                            values.Add(Convert.ToDouble(item));
                        }
                      
                    }
                    values[3] = Math.Truncate(100 * values[3]) / 100;
        
                    txtSession.Text = values[0].ToString();
                    txtUsers.Text = values[1].ToString();
                    txtPageViews.Text = values[2].ToString();
                    txtBounceRate.Text = values[3].ToString();
                    txtVisits.Text = values[4].ToString();
                   
                }
        
        
             public static dynamic GetAccessToken(string clientIdEMail, string keyFilePath, string scope)
            {
                // certificate
                var certificate = new X509Certificate2(keyFilePath, "notasecret");
        
                // header
                var header = new { typ = "JWT", alg = "RS256" };
        
                // claimset
                var times = GetExpiryAndIssueDate();
                var claimset = new
                {
                    iss = clientIdEMail,
                    scope = scope,
                    aud = "https://accounts.google.com/o/oauth2/token",
                    iat = times[0],
                    exp = times[1],
                };
        
                JavaScriptSerializer ser = new JavaScriptSerializer();
        
                // encoded header
                var headerSerialized = ser.Serialize(header);
                var headerBytes = Encoding.UTF8.GetBytes(headerSerialized);
                var headerEncoded = Convert.ToBase64String(headerBytes);
        
                // encoded claimset
                var claimsetSerialized = ser.Serialize(claimset);
                var claimsetBytes = Encoding.UTF8.GetBytes(claimsetSerialized);
                var claimsetEncoded = Convert.ToBase64String(claimsetBytes);
        
                // input
                var input = headerEncoded + "." + claimsetEncoded;
                var inputBytes = Encoding.UTF8.GetBytes(input);
        
                // signature
                var rsa = certificate.PrivateKey as RSACryptoServiceProvider;
                var cspParam = new CspParameters
                {
                    KeyContainerName = rsa.CspKeyContainerInfo.KeyContainerName,
                    KeyNumber = rsa.CspKeyContainerInfo.KeyNumber == KeyNumber.Exchange ? 1 : 2
                };
                var aescsp = new RSACryptoServiceProvider(cspParam) { PersistKeyInCsp = false };
                var signatureBytes = aescsp.SignData(inputBytes, "SHA256");
                var signatureEncoded = Convert.ToBase64String(signatureBytes);
        
                // jwt
                var jwt = headerEncoded + "." + claimsetEncoded + "." + signatureEncoded;
        
                var client = new WebClient();
                client.Encoding = Encoding.UTF8;
                var uri = "https://accounts.google.com/o/oauth2/token";
                var content = new NameValueCollection();
        
                content["assertion"] = jwt;
                content["grant_type"] = "urn:ietf:params:oauth:grant-type:jwt-bearer";
        
                string response = Encoding.UTF8.GetString(client.UploadValues(uri, "POST", content));
        
        
                var result = ser.Deserialize<dynamic>(response);
        
                object pulledObject = null;
        
                string token = "access_token";
                if (result.ContainsKey(token))
                {
                    pulledObject = result[token];
                }
        
        
                //return result;
                return pulledObject;
            }
        
            private static int[] GetExpiryAndIssueDate()
            {
                var utc0 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                var issueTime = DateTime.UtcNow;
        
                var iat = (int)issueTime.Subtract(utc0).TotalSeconds;
                var exp = (int)issueTime.AddMinutes(55).Subtract(utc0).TotalSeconds;
        
                return new[] { iat, exp };
            }
        
            }
        }
