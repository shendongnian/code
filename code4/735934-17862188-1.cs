    private void simpleButton_Comparer_Click(object sender, EventArgs e)
    {
        string LeFile_Client = System.IO.Path.Combine(appDir, @"FA.csv");
        string LeFile_Server = System.IO.Path.Combine(appDir, @"FA_Server.csv");
        var ListClient = Outils.GetCsv(LeFile_Client).OrderBy(t => t.LettreVoidID);
        var ListServer = Outils.GetCsvServer(LeFile_Server).OrderBy(t => t.LettreVoidID); 
        var LeDiff = ListServer.Except(ListClient).Concat(ListClient.Except(ListServer));
  
        var result = new StringBuilder();
        foreach (var Diff in LeDiff)
        {
            result.AppendFormat("{0} --{1} ", Diff.LettreVoidID, Diff.OrdreCummul);
        }
        MessageBox.Show(Noid.ToString() + "--" + OdreID);
    }
