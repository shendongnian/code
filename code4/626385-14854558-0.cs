    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web;
    public class ExpirationModule : IHttpModule {
        HttpApplication _context;
        
        #region static initialization for this example - this should be a config section
        
        static Dictionary<string, TimeSpan> ExpirationTimes;
        static TimeSpan DefaultExpiration = TimeSpan.FromMinutes(15);
        static CrlExpirationModule() {       
            ExpirationTimes = new Dictionary<string, TimeSpan>();
            ExpirationTimes["~/SOMEFOLDER/SOMEFILE.XYZ"] = TimeSpan.Parse("0.0:30");
            ExpirationTimes["~/ANOTHERFOLDER/ANOTHERFILE.XYZ"] = TimeSpan.Parse("1.1:00");
        }
        
        #endregion
        
        public void Init(HttpApplication context) {
            _context = context;
            _context.EndRequest += ContextEndRequest;
        }
        void ContextEndRequest(object sender, EventArgs e) {
            // don't use Path as it contains the application name
            string requestPath = _context.Request.AppRelativeCurrentExecutionFilePath;
            string expirationTimesKey = requestPath.ToUpperInvariant();
            if (!ExpirationTimes.ContainsKey(expirationTimesKey)) {
                // not a file we manage
                return;
            }
            string physicalPath = _context.Request.PhysicalPath;
            if (!File.Exists(physicalPath)) {
                // we do nothing and let IIS return a regular 404 response
                return;
            }
            FileInfo fileInfo = new FileInfo(physicalPath);
            DateTime expirationTime = fileInfo.LastWriteTimeUtc.Add(ExpirationTimes[expirationTimesKey]);
            if (expirationTime <= DateTime.UtcNow) {
                expirationTime = DateTime.UtcNow.Add(DefaultExpiration);
            }
            _context.Response.Cache.SetExpires(expirationTime);
        }
        public void Dispose() {
        }
    }
