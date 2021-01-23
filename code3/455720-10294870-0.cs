    private void repairClientsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (machineList.Count() != 0)
        {
            AllFinished=False;
            new Thread(new ThreadStart(fixAllClients).Start();
        }
        else
        {
             MessageBox.Show("Please import data before attempting this procedure");
        }
    }
    
    private void fixAllClients(){
        var options = new ParallelOptions{MaxDegreeOfParallelism=10};
        Parallel.ForEach(machineList. options, fixClient);
        AllFinished=True;
    }
