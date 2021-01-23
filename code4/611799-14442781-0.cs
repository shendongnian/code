    foreach (Process process in Process.GetProcesses())
    {
        string[] itemArray = {process.ProcessName};
        item = new ListViewItem(itemArray) {BackColor = Color.White};
        yourListView.Items.Add(item);				
    }
    
