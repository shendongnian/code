    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    
        if (IsPostBack)
        {
            bool isButtonPostBackEvent = Request.Form.AllKeys.Contains(Button1.UniqueID);
            
            if (isButtonPostBackEvent)
            {
                RedirectToYahoo();
            }
        }
    }
