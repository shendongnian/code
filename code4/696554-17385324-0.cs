    namespace ServiceStackNTML
    {
       using ServiceStack.Common;
       using ServiceStack.ServiceHost;
       using ServiceStack.ServiceInterface;
       using ServiceStack.WebHost.Endpoints;
       using System;
       using System.Net;
   
       class Program
       {
           static void Main(string[] args)
           {
               var host = new NTMLAppHost();
               host.Init();
               host.Start("http://localhost:8080/");
   
               Console.ReadLine();
           }
       }
   
       class NTMLAppHost : AppHostHttpListenerBase
       {
           public NTMLAppHost() : base("Test", typeof(NTMLAppHost).Assembly) { }
   
           public override void Configure(Funq.Container container)
           {
               
           }
   
           public override void Start(string urlBase)
           {
               base.Start(urlBase);
               this.Listener.AuthenticationSchemes = System.Net.AuthenticationSchemes.Ntlm;
           }
   
           protected override void ProcessRequest(HttpListenerContext context)
           {
               HostContext.Instance.Items["User"] = context.User;
               base.ProcessRequest(context);
           }
       }
   
       class TestService : Service
       {
           public string Any(UsernameRequest request)
           {
               return ((System.Security.Principal.IPrincipal)HostContext.Instance.Items["User"]).Identity.Name;
           }
       }
   
       [Route("/Username")]
       class UsernameRequest : IReturn<string>
       {
           
       }
    }
