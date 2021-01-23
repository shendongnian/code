    private void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        BackgroundWorker worker = (BackgroundWorker)sender;            
        try
        {
            using (SPSite site = new SPSite((String)e.Argument))
            {
                SPWeb web = site.OpenWeb();
                SPGroupCollection collGroups = web.SiteGroups;
                if(GroupNames == null)
                    GroupNames = new List<string>();
                int added = 0;
                foreach(SPGroup oGroup in collGroups)
                {
                    added++;
                    ListViewItem tmp = new ListViewItem() {
                        Content = oGroup.Name
                    };
                    worker.ReportProgress((added * 100)/collGroups.Count,tmp);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Unable to locate a SharePoint site at: " + siteUrl);
        }
    }
