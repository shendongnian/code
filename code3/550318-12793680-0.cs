    public decimal ReportSales()
    {
        var currentUser = new WindowsPrincipal((WindowsIdentity)
        System.Threading.Thread.CurrentPrincipal.Identity);
        if (currentUser.IsInRole(WindowsBuiltInRole.BackupOperator))
        {
            return 10000M;
        }
        else
        {
           return -1M;
        }
     }
