    private void myProcess_Exited(object sender, System.EventArgs e)
    {
        Process pro = sender as Process; 
        string output = pro.StandardOutput.ReadToEnd()
        Console.WriteLine("log: {0}", output);
    }
