    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;
    namespace QuapiNet.Service
    {
        public class JwtTokenValidation
        {
            public async Task<Dictionary<string, X509Certificate2>> FetchGoogleCertificates()
            {
                using (var http = new HttpClient())
                {
                    var response = await http.GetAsync("https://www.googleapis.com/oauth2/v1/certs");
                    var dictionary = await response.Content.ReadAsAsync<Dictionary<string, string>>();
                    return dictionary.ToDictionary(x => x.Key, x => new X509Certificate2(Encoding.UTF8.GetBytes(x.Value)));
                }
            }
            private string CLIENT_ID = "xxx.apps.googleusercontent.com";
            public async Task<ClaimsPrincipal> ValidateToken(string idToken)
            {
                var certificates = await this.FetchGoogleCertificates();
                TokenValidationParameters tvp = new TokenValidationParameters()
                {
                    ValidateActor = false, // check the profile ID
                    ValidateAudience = true, // check the client ID
                    ValidAudience = CLIENT_ID,
                    ValidateIssuer = true, // check token came from Google
                    ValidIssuers = new List<string> { "accounts.google.com", "https://accounts.google.com" },
                    ValidateIssuerSigningKey = true,
                    RequireSignedTokens = true,
                    IssuerSigningKeys = certificates.Values.Select(x => new X509SecurityKey(x)),
                    IssuerSigningKeyResolver = (token, securityToken, kid, validationParameters) =>
                    {
                        return certificates
                        .Where(x => x.Key.ToUpper() == kid.ToUpper())
                        .Select(x => new X509SecurityKey(x.Value));
                    },
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.FromHours(13)
                };
                JwtSecurityTokenHandler jsth = new JwtSecurityTokenHandler();
                SecurityToken validatedToken;
                ClaimsPrincipal cp = jsth.ValidateToken(idToken, tvp, out validatedToken);
                return cp;
            }
        }
    }
