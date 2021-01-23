       public override void ProcessRequest(
                 IHttpRequest httpReq, IHttpResponse httpRes, string operationName)
        {
            
            if ( FileFormat == DefaultFileFormat.Markdown ) 
            {
                ProcessMarkdownPage(httpReq, httpRes, operationName);
                return;
            }	
            if ( FileFormat == DefaultFileFormat.Razor ) 
            {
                ProcessRazorPage(httpReq, httpRes, operationName);
                return;
            }
            
            fi.Refresh();
            if (fi.Exists)
            {
                ProcessStaticPage(httpReq, httpRes, operationName);
                return;
            }
            
            ProcessServerError(httpReq, httpRes, operationName);
            
        }	
