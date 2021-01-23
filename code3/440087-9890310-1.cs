    public ReportPage()
    {
        this.Init += (o, e) =>
        {
            // if the local time is not saved yet in Session and the request has not posted the localTime
            if (Session["localTime"] == null && String.IsNullOrEmpty(Request.Params["localTime"]))
            {
                // then clear the content and write some html, a javascript code which submits the local time
                Response.ClearContent();
                Response.Write(@"<form id='local' method='post' name='local'>
                                    <input type='hidden' id='localTime' name='localTime' />
                                    <script type='text/javascript'>
                                        document.getElementById('localTime').value = new Date();
                                        document.getElementById('local').submit();
                                    </script>
                                </form>");
                // 
                Response.Flush();
    
                // end the response so PageLoad, PagePreRender etc won't be executed
                Response.End();
            }
            else
            {
                // if the request contains the localtime, then save it in Session
                if (Request.Params["localTime"] != null)
                {
                    Session["localTime"] = Request.Params["localTime"];
                    // and redirect back to the original url
                    Response.Redirect(Request.RawUrl);
                }
            }
        };
    }
