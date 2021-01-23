    StringBuilder sb = new System.Text.StringBuilder();
    foreach (var svc in System.ServiceProcess.ServiceController.GetServices())
    {
        sb.AppendLine("============================");
        sb.AppendLine(svc.DisplayName);
        foreach (var dep in svc.DependentServices)
        {
            sb.AppendFormat("\t{0}", dep.DisplayName);
            sb.AppendLine();
        }
    }
    MessageBox.Show(sb.ToString());
