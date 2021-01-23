    public partial class Form1 : Form
    {
    public Form1()
    {
    this.InitializeComponent();
    this.StartPosition = FormStartPosition.CenterScreen;
    this.LocationChanged += OnLocationChanged;
    }
    private void OnLocationChanged(object sender, EventArgs eventArgs)
    {
    Screen screen = Screen.FromHandle(this.Handle);
    if (!screen.WorkingArea.Contains(this.Location))
    this.Location = screen.Bounds.Location;
    }
    }
