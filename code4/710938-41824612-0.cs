    OpenFileDialog oFileD = new OpenFileDialog();
    oFileD.InitialDirectory = initialDir;
    oFileD.FileName = fileName;
    if (oFileD.FileName != "")
    {
        Timer t = new Timer();
        t.Interval = 100;
        t.Tick += (s, e) =>
        {
            SendKeys.Send("{HOME}+{END}");
            t.Stop();
        };
        t.Start();
    }
    if (oFileD.ShowDialog() == DialogResult.OK) {
        ...
    }
