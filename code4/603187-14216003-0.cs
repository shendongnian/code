    System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(sendmail), new Object());
    public void sendmail(object o)
    {
    
        System.Web.UI.Page() pageHolder = new System.Web.UI.Page() 
                  {AppRelativeTemplateSourceDirectory = HttpRuntime.AppDomainAppVirtualPath };
        System.Web.UI.HtmlControls.HtmlForm form = new System.Web.UI.HtmlControls.HtmlForm();
        UserControl cntrl = new Page().LoadControl("~/mycontrol.ascx") as UserControl;
        form.Controls.Add(cntrl );
        pageHolder.Controls.Add(form);
       
        StringWriter stringwriter = new StringWriter();
       
        HttpContext.Current.Server.Execute(pageHolder, stringwriter, false);
        SendEmailUsingNetMail(stringwriter);
    }
