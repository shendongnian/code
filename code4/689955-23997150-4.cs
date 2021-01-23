	namespace YourProjectNamespace
	{
		public partial class Form1 : Form
		{
			//  Declare
			public static dataGlobal dataMain = new dataGlobal();
			public Form1()
			{
				InitializeComponent();
				
				// Initialize
				dataMain.txtConsole = textBox1;
			}
			// Your own Form1 code goes on...
		}
	}
