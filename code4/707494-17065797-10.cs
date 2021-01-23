	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Collections;
	using System.Runtime.Serialization;
	using System.Net;
	using System.Net.Http;
	using System.Threading.Tasks;
	using System.Web;
	using System.IO;
	using System.Runtime.Serialization.Json;
	namespace WopiServerTutorial
	{
		public class WopiServer
		{
			private HttpListener Listener;
			static void Main(string[] args)
			{
				WopiServer s = new WopiServer();
				s.Start();
				Console.WriteLine("A simple wopi webserver. Press a key to quit.");
				Console.ReadKey();
				s.Stop();
			}
			public void Start()
			{
				Listener = new HttpListener();
				Listener.Prefixes.Add(@"http://+:8080/");
				Listener.Start();
				Listener.BeginGetContext(ProcessRequest, Listener);
				Console.WriteLine(@"WopiServer Started");
			}
			public void Stop()
			{
				Listener.Stop();
			}
			private void ProcessRequest(IAsyncResult result)
			{
				HttpListener listener = (HttpListener)result.AsyncState;
				HttpListenerContext context = listener.EndGetContext(result);
				Console.WriteLine(@"Got a " + context.Request.HttpMethod  + " request for URL: " + context.Request.Url.PathAndQuery);
				var stringarr = context.Request.Url.AbsolutePath.Split('/');
				var rootDir = @"C:\\temp\\";
				if (stringarr.Length == 5 && context.Request.HttpMethod.Equals(@"GET"))
				{
					Console.WriteLine(@"Getting content for the file: " + rootDir + stringarr[3]);
					// get file's content
					var file = rootDir + stringarr[3];
					var stream = new FileStream(file, FileMode.Open);
					var fi = new FileInfo(file);
					context.Response.ContentType = @"application/octet-stream";
					context.Response.ContentLength64 = fi.Length;
					stream.CopyTo(context.Response.OutputStream);
					context.Response.Close();
				}
				//else if (stringarr.Length == 5 && context.Request.HttpMethod.Equals(@"POST"))
				//{
				//    // write
				//}
				else if (stringarr.Length == 4 && context.Request.HttpMethod.Equals(@"GET"))
				{
					Console.WriteLine(@"Getting metdata for the file: " + rootDir + stringarr[3]);
					var fi = new FileInfo(rootDir + stringarr[3]);
					CheckFileInfo cfi = new CheckFileInfo();
					cfi.AllowExternalMarketplace = false;
					cfi.BaseFileName = fi.Name;
					cfi.BreadcrumbBrandName = "";
					cfi.BreadcrumbBrandUrl = "";
					cfi.BreadcrumbDocName = "";
					cfi.BreadcrumbDocUrl = "";
					cfi.BreadcrumbFolderName = "";
					cfi.BreadcrumbFolderUrl = "";
					cfi.ClientUrl = "";
					cfi.CloseButtonClosesWindow = false;
					cfi.CloseUrl = "";
					cfi.DisableBrowserCachingOfUserContent = true;
					cfi.DisablePrint = true;
					cfi.DisableTranslation = true;
					cfi.DownloadUrl = "";
					cfi.FileUrl = "";
					cfi.FileSharingUrl = "";
					cfi.HostAuthenticationId = "s-1-5-21-3430578067-4192788304-1690859819-21774";
					cfi.HostEditUrl = "";
					cfi.HostEmbeddedEditUrl = "";
					cfi.HostEmbeddedViewUrl = "";
					cfi.HostName = @"SharePoint";
					cfi.HostNotes = @"HostBIEnabled";
					cfi.HostRestUrl = "";
					cfi.HostViewUrl = "";
					cfi.IrmPolicyDescription = "";
					cfi.IrmPolicyTitle = "";
					cfi.OwnerId = @"4257508bfe174aa28b461536d8b6b648";
					cfi.PresenceProvider = "AD";
					cfi.PresenceUserId = @"S-1-5-21-3430578067-4192788304-1690859819-21774";
					cfi.PrivacyUrl = "";
					cfi.ProtectInClient = false;
					cfi.ReadOnly = false;
					cfi.RestrictedWebViewOnly = false;
					cfi.SHA256 = "";
					cfi.SignoutUrl = "";
					cfi.Size = fi.Length;
					cfi.SupportsCoauth = false;
					cfi.SupportsCobalt = false;
					cfi.SupportsFolders = false;
					cfi.SupportsLocks = true;
					cfi.SupportsScenarioLinks = false;
					cfi.SupportsSecureStore = false;
					cfi.SupportsUpdate = true;
					cfi.TenantId = @"33b62539-8c5e-423c-aa3e-cc2a9fd796f2";
					cfi.TermsOfUseUrl = "";
					cfi.TimeZone = @"+0300#0000-11-00-01T02:00:00:0000#+0000#0000-03-00-02T02:00:00:0000#-0060";
					cfi.UserCanAttend = false;
					cfi.UserCanNotWriteRelative = false;
					cfi.UserCanPresent = false;
					cfi.UserCanWrite = true;
					cfi.UserFriendlyName = "";
					cfi.UserId = "";
					cfi.Version = @"%22%7B59CCD75F%2D0687%2D4F86%2DBBCF%2D059126640640%7D%2C1%22";
					cfi.WebEditingDisabled = false;
					// encode json
					var memoryStream = new MemoryStream();
					var json = new DataContractJsonSerializer(typeof(CheckFileInfo));
					json.WriteObject(memoryStream, cfi);
					memoryStream.Flush();
					memoryStream.Position = 0;
					StreamReader streamReader = new StreamReader(memoryStream);
					var jsonResponse = Encoding.UTF8.GetBytes(streamReader.ReadToEnd());
					context.Response.ContentType = @"application/json";
					context.Response.ContentLength64 = jsonResponse.Length;
					context.Response.OutputStream.Write(jsonResponse, 0, jsonResponse.Length);
					context.Response.Close();
				}
				else
				{
					byte[] buffer = Encoding.UTF8.GetBytes("");
					context.Response.ContentLength64 = buffer.Length;
					context.Response.ContentType = @"application/json";
					context.Response.OutputStream.Write(buffer, 0, buffer.Length);
					context.Response.OutputStream.Close();
				}
				Listener.BeginGetContext(ProcessRequest, Listener);
			}
		}
		[DataContract]
		public class CheckFileInfo
		{
			[DataMember]
			public bool AllowExternalMarketplace { get; set; }
			[DataMember]
			public string BaseFileName { get; set; }
			[DataMember]
			public string BreadcrumbBrandName { get; set; }
			[DataMember]
			public string BreadcrumbBrandUrl { get; set; }
			[DataMember]
			public string BreadcrumbDocName { get; set; }
			[DataMember]
			public string BreadcrumbDocUrl { get; set; }
			[DataMember]
			public string BreadcrumbFolderName { get; set; }
			[DataMember]
			public string BreadcrumbFolderUrl { get; set; }
			[DataMember]
			public string ClientUrl { get; set; }
			[DataMember]
			public bool CloseButtonClosesWindow { get; set; }
			[DataMember]
			public string CloseUrl { get; set; }
			[DataMember]
			public bool DisableBrowserCachingOfUserContent { get; set; }
			[DataMember]
			public bool DisablePrint { get; set; }
			[DataMember]
			public bool DisableTranslation { get; set; }
			[DataMember]
			public string DownloadUrl { get; set; }
			[DataMember]
			public string FileSharingUrl { get; set; }
			[DataMember]
			public string FileUrl { get; set; }
			[DataMember]
			public string HostAuthenticationId { get; set; }
			[DataMember]
			public string HostEditUrl { get; set; }
			[DataMember]
			public string HostEmbeddedEditUrl { get; set; }
			[DataMember]
			public string HostEmbeddedViewUrl { get; set; }
			[DataMember]
			public string HostName { get; set; }
			[DataMember]
			public string HostNotes { get; set; }
			[DataMember]
			public string HostRestUrl { get; set; }
			[DataMember]
			public string HostViewUrl { get; set; }
			[DataMember]
			public string IrmPolicyDescription { get; set; }
			[DataMember]
			public string IrmPolicyTitle { get; set; }
			[DataMember]
			public string OwnerId { get; set; }
			[DataMember]
			public string PresenceProvider { get; set; }
			[DataMember]
			public string PresenceUserId { get; set; }
			[DataMember]
			public string PrivacyUrl { get; set; }
			[DataMember]
			public bool ProtectInClient { get; set; }
			[DataMember]
			public bool ReadOnly { get; set; }
			[DataMember]
			public bool RestrictedWebViewOnly { get; set; }
			[DataMember]
			public string SHA256 { get; set; }
			[DataMember]
			public string SignoutUrl { get; set; }
			[DataMember]
			public long Size { get; set; }
			[DataMember]
			public bool SupportsCoauth { get; set; }
			[DataMember]
			public bool SupportsCobalt { get; set; }
			[DataMember]
			public bool SupportsFolders { get; set; }
			[DataMember]
			public bool SupportsLocks { get; set; }
			[DataMember]
			public bool SupportsScenarioLinks { get; set; }
			[DataMember]
			public bool SupportsSecureStore { get; set; }
			[DataMember]
			public bool SupportsUpdate { get; set; }
			[DataMember]
			public string TenantId { get; set; }
			[DataMember]
			public string TermsOfUseUrl { get; set; }
			[DataMember]
			public string TimeZone { get; set; }
			[DataMember]
			public bool UserCanAttend { get; set; }
			[DataMember]
			public bool UserCanNotWriteRelative { get; set; }
			[DataMember]
			public bool UserCanPresent { get; set; }
			[DataMember]
			public bool UserCanWrite { get; set; }
			[DataMember]
			public string UserFriendlyName { get; set; }
			[DataMember]
			public string UserId { get; set; }
			[DataMember]
			public string Version { get; set; }
			[DataMember]
			public bool WebEditingDisabled { get; set; }
		}
	}
