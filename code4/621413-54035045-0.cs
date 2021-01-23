    public partial class Window : System.Windows.Window{
    public Window()
    {
        InitializeComponent();
        System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
        ni.Icon = new System.Drawing.Icon("Main.ico");
        ni.Visible = true;
        ni.DoubleClick += 
            delegate(object sender, EventArgs args)
            {
                this.Show();
                this.WindowState = WindowState.Normal;
            };
    }
    protected override void OnStateChanged(EventArgs e)
    {
        if (WindowState == WindowState.Minimized)
            this.Hide();
        base.OnStateChanged(e);
    }}
