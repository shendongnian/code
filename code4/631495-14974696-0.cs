    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.IO;
    using System.Threading;
    using RestSharp;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication2
    {
        public class SimpleConnector
        {
            private CookieContainer _cookieJar = new CookieContainer();
            private RestClient client = new RestClient();
            public string TwitterAuthenticate(string user, string pass)
            {
                client.CookieContainer = _cookieJar;
                //RestClient client = new RestClient("https://twitter.com");
                IRestRequest request = new RestRequest("https://twitter.com/", Method.GET);
                client.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:18.0) Gecko/20100101 Firefox/18.0";
                client.AddDefaultHeader("Accept", "*/*");
                //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
                //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
    
                // easily add HTTP Headers
                //request.AddHeader("header", "value");
    
                // add files to upload (works with compatible verbs)
    
                // execute the request
                IRestResponse response = client.Execute(request);
                var content = response.Content;
                Match m = Regex.Match(content, @"name=""authenticity_token""\s*value=""(.*?)"">");
                string authenticity_token = m.Groups[1].Value;
                request = new RestRequest("https://twitter.com/sessions", Method.POST);
                request.AddParameter("session[username_or_email]", user);
                request.AddParameter("session[password]", pass);
                request.AddParameter("return_to_ssl", "true");
                request.AddParameter("scribe_log", "");
                request.AddParameter("redirect_after_login", "/");
                request.AddParameter("authenticity_token", authenticity_token);
                response = client.Execute(request);
                content = response.Content;
                return content;
            }
