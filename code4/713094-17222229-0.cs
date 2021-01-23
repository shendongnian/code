    try
    {
        reader = new Reader("COM6");
    }
    catch
    {
        MessageBox.Show("No Device Detected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        return; // Will exit the program
    }
    Application.EnableVisualStyles();
    //... Other code here..
