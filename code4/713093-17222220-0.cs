    bool readerCompleted = false;
    try
    {
        reader = new Reader("COM6");
        readerCompleted = true;
    }
    catch
    {
        MessageBox.Show("No Device Detected", MessageBoxButtons.OK, MessageBoxIcon.Error)
    }
    if(readerCompleted)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleRenderingDefault(false);
        Application.Run(new Form1());
    }
