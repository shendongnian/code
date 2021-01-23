    private void EnableCrossDomainAjaxCall()
                {
                    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
        
                    if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
                    {
                        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Authorization, Accept");
                        HttpContext.Current.Response.End();
                    }
                }
