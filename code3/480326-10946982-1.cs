    public partial class MainForm : Form
    {
    public MainForm()
    {
        InitializeComponent();
        Delegation.Invoke(Delegation.msgboz1);
        Delegation.Invoke(Delegation.msbox2);
    }
    }
    class Delegation
    {    
    public delegate void mbox ();
    public static void msgboz1()
    {
        MessageBox.Show("1rstBox");
    }
    public static void msbox2()
    { 
        MessageBox.Show("2ndbox");
    }
    public static void Invoke(mbox method)
    { 
        method();
    }
    }
