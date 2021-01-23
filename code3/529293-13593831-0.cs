            public SynchronousPost()
            {
                Client = new WebClient { UseDefaultCredentials = true };
            }
        
            public void PostEntity(T PostThis,string ApiControllerName)//The ApiController name should be "/api/MyName/"
            {
                //this just determines the root url. 
                Client.BaseAddress = string.Format(
             (
                System.Web.HttpContext.Current.Request.Url.Port != 80) ? "{0}://{1}:{2}" : "{0}://{1}",
                System.Web.HttpContext.Current.Request.Url.Scheme,
                System.Web.HttpContext.Current.Request.Url.Host,
                System.Web.HttpContext.Current.Request.Url.Port
               );
                Client.Headers.Add(HttpRequestHeader.ContentType, "application/json;charset=utf-8");
                Client.UploadData(
                                     ApiControllerName, "Post", 
                                     Encoding.UTF8.GetBytes
                                     (
                                        JsonConvert.SerializeObject(PostThis)
                                     )
                                 );  
            }
            private WebClient Client  { get; set; }
        }
