    using System;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace Test
    {
    	public partial class RunnableForm : Form
    	{
    		public RunnableForm()
    		{
    			InitializeComponent();
    		}
    
    		private void button1_Click(object sender, EventArgs e)
    		{
    			MessageBox.Show("bang!");
    		}
    
    		[STAThread]
    		static void Main()
    		{
    			
    			string[] args = Environment.GetCommandLineArgs();
    			// We'll always have one argument (the program's exe is args[0])
    			if (args.Length == 1)
    			{
    				// Run windows forms app
    				Application.Run(new RunnableForm());
    			}
    			else
    			{
    				Console.WriteLine("We'll run as a console app now");
    				Console.WriteLine("Arguments: {0}", String.Join(",", args.Skip(1)));
    				Console.Write("Enter a string: ");
    				string str = Console.ReadLine();
    				Console.WriteLine("You entered: {0}", str);
    				Console.WriteLine("Bye.");
    			}
    		}
    	}
    }
