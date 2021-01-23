    Process process = Process.Start(@"Data\myApp.exe");
    int id = process.Id;
    Process tempProc = Process.GetProcessById(id);
    this.Visible = false;
    tempProc.WaitForExit();
    this.Visible = true;
