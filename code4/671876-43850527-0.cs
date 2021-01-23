    public partial class Form1 : Form
    {
    	public Form1()
    	{
    		InitializeComponent();
    		HookKeys x = new HookKeys();
    		x.Start();
    		x.HookEvent += new HookKeys.HookEventHandler(HookEvent);
    	}
    
    	private void HookEvent(HookEventArgs e, KeyBoardInfo keyBoardInfo)
    	{
    		textBox1.Text = "vkCode = " + keyBoardInfo.vkCode + Environment.NewLine + textBox1.Text;
    	}
    }
