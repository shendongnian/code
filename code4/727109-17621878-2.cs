    public void process_Exited(object sender, EventArgs e) 
    {
        Process myProcess = (Process)sender;
        // use myProcess to determine which job number....
        var jobNumber = _processDictionary[myProcess];
        _processDictionary.Remove(myProcess);
        // DoWork
    }
