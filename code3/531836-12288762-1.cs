    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            bindServices();
    }
    private void bindServices()
    {
        ServiceController[] services = ServiceController.GetServices();
        rptServices.DataSource = services;
        rptServices.DataBind();
    }
    [WebMethod]
    public static string ChangeStatus(string newStatus, string displayName)//
    {
        Debug.WriteLine(string.Format("Service {0} new status {1}", displayName, newStatus));
        ServiceController sc = new ServiceController(displayName);
        switch (newStatus)
        {
            case "Start":
                sc.Start();
                // instead of waiting on the SERVER for xxx secondes 
                // immediately RETURN to CLIENT
                //sc.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 15));
                break;
            case "Stop":
                sc.Stop();
                break;
            case "Pause":
                sc.Pause();
                break;
            case "Continue":
                sc.Continue();
                break;
            default:
                break;
        }
        return sc.Status.ToString();
    }
