    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using Jira
    using RestSharp;
    using RestSharp.Authenticators;
    namespace Jira
    {
        class Program
        {
          static void Main(string[] args)
          {
            var client = new RestClient("http://{URL}/rest/api/2");
            var request = new RestRequest("issue/", Method.POST);
      
            client.Authenticator = new HttpBasicAuthenticator("user", "pass");
            
            var issue = new Issue
            {
                fields =
                    new Fields
                    {
                        description = "Issue Description",
                        summary = "Issue Summary",
                        project = new Project { key = "KEY" }, 
                        issuetype = new IssueType { name = "ISSUE_TYPE_NAME" }
                    }
            };
            
            request.AddJsonBody(issue);
            
            var res = client.Execute<Issue>(request);
            
            if (res.StatusCode == HttpStatusCode.Created)
            {
                Console.WriteLine("Issue: {0} successfully created", res.Data.key);
                
                #region Attachment            
                request = new RestRequest(string.Format("issue/{0}/attachments", res.Data.key), Method.POST);
                            
                request.AddHeader("X-Atlassian-Token", "nocheck");
                
                var file = File.ReadAllBytes(@"C:\FB_IMG_1445253679378.jpg");
                request.AddHeader("Content-Type", "multipart/form-data");
                request.AddFileBytes("file", file, "FB_IMG_1445253679378.jpg", "application/octet-stream");
                
                var res2 = client.Execute(request);
                Console.WriteLine(res2.StatusCode == HttpStatusCode.OK ? "Attachment added!" : res2.Content);
                #endregion
            }
            else
                Console.WriteLine(res.Content);
          }
        }
        
        public class Issue
        {
            public string id { get; set; }
            public string key { get; set; }
            public Fields fields { get; set; }
        }
        
        public class Fields
        {
            public Project project { get; set; }
            public IssueType issuetype { get; set; }
            public string summary { get; set; }
            public string description { get; set; }        
        }
        
        public class Project
        {
            public string id { get; set; }
            public string key { get; set; }
        }
        
        public class IssueType
        {
            public string id { get; set; }
            public string name { get; set; }
        }
    }
