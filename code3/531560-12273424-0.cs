    public static Control GetPostBackControl(Page page)
    {
        Control postbackControlInstance = null;
 
        string postbackControlName = page.Request.Params.Get("__EVENTTARGET");
        if (postbackControlName != null && postbackControlName != string.Empty)
        {
            postbackControlInstance = page.FindControl(postbackControlName);
        }
        else
        {
            // handle the Button control postbacks
            for (int i = 0; i < page.Request.Form.Keys.Count; i++)
            {
                postbackControlInstance = page.FindControl(page.Request.Form.Keys[i]);
                if (postbackControlInstance is System.Web.UI.WebControls.Button)
                {
                    return postbackControlInstance;
                }
            }
        }
        // handle the ImageButton postbacks
        if (postbackControlInstance == null)
        {
            for (int i = 0; i < page.Request.Form.Count; i++)
            {
                if ( (page.Request.Form.Keys[i].EndsWith(".x")) || (page.Request.Form.Keys[i].EndsWith(".y")))
                {
                    postbackControlInstance = page.FindControl(page.Request.Form.Keys[i].Substring(0, page.Request.Form.Keys[i].Length-2) );
                    return postbackControlInstance;
                }
            }
        }
        return postbackControlInstance;
    }   
