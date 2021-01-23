            internal HttpResponse (HttpWorkerRequest worker_request, HttpContext context) : this ()
            {
                WorkerRequest = worker_request;
                this.context = context;
    
    #if !TARGET_J2EE
                if (worker_request != null)
                {
                   
                    if(worker_request.GetHttpVersion () == "HTTP/1.1")
                    {
                        string GatewayIface = context.Request.ServerVariables["GATEWAY_INTERFACE"];
                        use_chunked = (GatewayIface == null || !GatewayIface.StartsWith("CGI"));
                    }
                    else
                        use_chunked = false;
                   
                }
    #endif
                writer = new HttpWriter (this);
            }
