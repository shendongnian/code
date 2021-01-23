    using System;
    using System.Net;
    
    namespace SharePoint.Client.Office
    {
        public class ExcelClient : IDisposable
        {
    
            public ExcelClient(Uri webUri, ICredentials credentials)
            {
                WebUri = webUri;
                _client = new WebClient {Credentials = credentials};
            }
    
    
            public string ReadTable(string libraryName, string tableName,string formatType)
            {
                var endpointUrl = string.Format("{0}/_vti_bin/ExcelRest.aspx/{1}/ciscoexpo.xlsx/Model/Tables('{2}')?$format={3}", WebUri,libraryName, tableName, formatType);
                return _client.DownloadString(endpointUrl);
            }
    
    
            public void Dispose()
            {
                _client.Dispose();
                GC.SuppressFinalize(this);
            }
    
            public Uri WebUri { get; private set; }
    
            private readonly WebClient _client;
    
        }
    }
