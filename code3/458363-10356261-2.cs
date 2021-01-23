    // create a list of process
    private List<Process> processes = new List<Process>();
    // if you start a process
    Process myProcess = //;
    processes.Add(myProcess);
    // on closing
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        var isAProcessRunning = processes.Where(p => p.HasExited == false);
        if (isAProcessRunning.Any()) 
        {
          // some process is already running, ask the user 
            if (MessageBox.Show("Are you sure you want to quit?", "Confirm Quit", MessageBoxButtons.YesNo) ==
            DialogResult.No)
            {
                e.Cancel = true;
            }
         }
      }
