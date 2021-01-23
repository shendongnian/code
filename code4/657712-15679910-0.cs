    public partial class Form1 : Form
    {
    Dictionary<String, ProgressBar> progressBars = new Dictionary<String, ProgressBar>();
    static Form1 _form1 = null;
    static int pbCounter = 1;
    public Form1()
    {
        InitializeComponent();
        _form1 = this;
    }
    public static Form1 GetInstance() {
        return _form1;
    }
