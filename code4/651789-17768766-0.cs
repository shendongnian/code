    public class HttpUploadModule : IHttpModule
    {
        public static DateTime lastClean = DateTime.UtcNow;
        public static TimeSpan cleanInterval = new TimeSpan(0,10,0);
        public static readonly object cleanLocker = new object();
        public static readonly Dictionary<Guid,UploadData> Uploads = new Dictionary<Guid,UploadData>();
        public const int KB = 1024;
        public const int MB = KB * 1024;
        public static void CleanUnusedResources( HttpContext context) 
        {
            if( lastClean.Add( cleanInterval ) < DateTime.UtcNow ) {
                lock( cleanLocker ) 
                {
                    
                    if( lastClean.Add( cleanInterval ) < DateTime.UtcNow ) 
                    {
                        int maxAge = int.Parse(ConfigurationManager.AppSettings["HttpUploadModule.MaxAge"]);
                        Uploads.Where(u=> DateTime.UtcNow.AddSeconds(maxAge) > u.Value.createdDate ).ToList().ForEach(u=>{    
                            Uploads.Remove(u.Key);
                        });
                        Directory.GetFiles(context.Server.MapPath(ConfigurationManager.AppSettings["HttpUploadModule.Folder"].TrimEnd('/'))).ToList().ForEach(f=>{     
                            if( DateTime.UtcNow.AddSeconds(maxAge) > File.GetCreationTimeUtc(f)) File.Delete(f);
                        });
                    
                        lastClean = DateTime.UtcNow;
                    }
                }
                
            }
        }
        public void Dispose()
        {   
            
        }
        public void Init(HttpApplication app)
        {
            app.BeginRequest += app_BeginRequest;
        }
        void app_BeginRequest(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            Guid uploadId = Guid.Empty;
            if (context.Request.HttpMethod == "POST" && context.Request.ContentType.ToLower().StartsWith("multipart/form-data"))
            {
                IServiceProvider provider = (IServiceProvider)context;
                HttpWorkerRequest wr = (HttpWorkerRequest)provider.GetService(typeof(HttpWorkerRequest));
                FileStream fs = null;
                MemoryStream ms = null;
                CleanUnusedResources(context);                
                
                string contentType = wr.GetKnownRequestHeader(HttpWorkerRequest.HeaderContentType);
                NameValueCollection queryString = HttpUtility.ParseQueryString( wr.GetQueryString() );
                UploadData upload = new UploadData { id = uploadId ,status = 0, createdDate = DateTime.UtcNow };
                
                if(
                                        !contentType.Contains("boundary=") ||   
                /*AT LAST 1KB        */ context.Request.ContentLength < KB ||
                /*MAX 5MB            */ context.Request.ContentLength > MB*5 || 
                /*IS UPLOADID        */ !Guid.TryParse(queryString["upload_id"], out uploadId) || Uploads.ContainsKey( uploadId )) {
                    upload.id = uploadId;
                    upload.status = 2;
                    Uploads.Add(upload.id, upload);
                    context.Response.StatusCode = 400;
                    context.Response.StatusDescription = "Bad Request";
                    context.Response.End();
                    
                }
                
                string boundary = Nancy.HttpMultipart.ExtractBoundary( contentType );
                upload.id = uploadId;
                upload.status = 0;
                Uploads.Add(upload.id, upload);
                
                try {
                    if (wr.HasEntityBody())
                    {
                        upload.bytesRemaining = 
                        upload.bytesTotal     = wr.GetTotalEntityBodyLength();
                    
                        upload.bytesLoaded    = 
                        upload.BytesReceived  = wr.GetPreloadedEntityBodyLength();
                        if (!wr.IsEntireEntityBodyIsPreloaded())
                        {
                            byte[] buffer = new byte[KB * 8];
                            int readSize = buffer.Length;
                            ms = new MemoryStream();
                            //fs = new FileStream(context.Server.MapPath(ConfigurationManager.AppSettings["HttpUploadModule.Folder"].TrimEnd('/')+'/' + uploadId.ToString()), FileMode.CreateNew);
                            while (upload.bytesRemaining > 0)
                            {
                                upload.BytesReceived = wr.ReadEntityBody(buffer, 0, readSize);
                            
                                if(upload.bytesRemaining == upload.bytesTotal) {
                                
                                }
                            
                                ms.Write(buffer, 0, upload.BytesReceived);
                                upload.bytesLoaded += upload.BytesReceived;
                                upload.bytesRemaining -= upload.BytesReceived;
                                if (readSize > upload.bytesRemaining)
                                {
                                    readSize = upload.bytesRemaining;
                                }
                            }
                            //fs.Flush();
                            //fs.Close();
                            ms.Position = 0;
                            //the file is in our hands
                            Nancy.HttpMultipart multipart = new Nancy.HttpMultipart(ms, boundary);
                            foreach( Nancy.HttpMultipartBoundary b in multipart.GetBoundaries()) {
                                if(b.Name == "data")   {
                                    
                                    upload.filename = uploadId.ToString()+Path.GetExtension( b.Filename ).ToLower();
                                    fs = new FileStream(context.Server.MapPath(ConfigurationManager.AppSettings["HttpUploadModule.Folder"].TrimEnd('/')+'/' + upload.filename  ), FileMode.CreateNew);
                                    b.Value.CopyTo(fs);
                                    fs.Flush();
                                    fs.Close();
                                    upload.status = 1;
                                    context.Response.StatusCode = 200;
                                    context.Response.StatusDescription = "OK";
                                    context.Response.Write(  context.Request.ApplicationPath.TrimEnd('/') + "/images/temp/" +  upload.filename  );
                                }
                            }
                        }
                    }
                }
                catch(Exception ex) {
                    upload.ex = ex;
                }
                if(upload.status != 1)
                {
                    upload.status = 2;
                    context.Response.StatusCode = 400;
                    context.Response.StatusDescription = "Bad Request";
                }
                context.Response.End();
            }
        }
    }
    public class UploadData {
        public Guid id { get;set; }
        public string filename {get;set;}
        public int bytesLoaded { get; set; }
        public int bytesTotal { get; set; }
        public int BytesReceived {get; set;}
        public int bytesRemaining { get;set; }
        public int status { get;set; }
        public Exception ex { get;set; }
        public DateTime createdDate { get;set; }
    } 
