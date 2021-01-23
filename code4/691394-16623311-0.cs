    var sri = Application.GetResourceStream(
        new Uri("pack://application:,,,/MyProj.Resources;component/Icons/Logo_48x48.png"));
    var bitmap = new Bitmap(sri.Stream);
    var handle = bitmap.GetHicon();
    var ni = new NotifyIcon {
        Icon = System.Drawing.Icon.FromHandle(handle),
        Visible = true
    };
