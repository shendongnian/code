    private void Form1_Load(object sender, EventArgs e)
    {
    string value64=null;
    RegistryKey localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
    localKey = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
    if (localKey != null)
    {
    value64 = localKey.GetValue("ProductID").ToString();
    }
    if (value64 == AllowedID)
    {
    MessageBox.Show("Successfully Authenticated");
    //run the application functions etc
    }
    else
    {
    MessageBox.Show("Error Authenticting");
    }
    }
