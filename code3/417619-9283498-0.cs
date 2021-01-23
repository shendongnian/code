	public class MyForm : Form
	{
		public MyForm()
		{
			InitializeComponent();
			
			
			// Method 1) The Tag property on any control can be used as user data
			radioButton1.Tag = Operation.Add;
			radioButton2.Tag = Operation.Subtract;
			radioButton3.Tag = Operation.Multiply;
			radioButton4.Tag = Operation.Divide;
			
			// Method 2) Use a Dictionary
			radioButtonToOperation = new Dictionary<RadioButton, Operation> 
				{
					{ radioButton1, Operation.Add },
					{ radioButton2, Operation.Subtract },
					{ radioButton3, Operation.Multiply },
					{ radioButton4, Operation.Divide },
				};
		}
		
		// Fields
		GroupBox groupBox1;
		RadioButton radioButton1;
		RadioButton radioButton2;
		RadioButton radioButton3;
		RadioButton radioButton4;
		Dictionary<RadioButton, Operation> radioButtonToOperation;
		
		private void InitializeComponent()
		{	
			groupBox1 = new GroupBox();
			radioButton1 = new RadioButton();
			radioButton2 = new RadioButton();
			radioButton3 = new RadioButton();
			radioButton4 = new RadioButton();
			
			groupBox1.Text = "Operations";
			groupBox1.Dock = DockStyle.Fill;
			
			radioButton1.Text = "Add";
			radioButton1.Dock = DockStyle.Top;
			radioButton1.CheckedChanged += radioButtons_CheckedChanged;
			
			radioButton2.Text = "Subtract";
			radioButton2.Dock = DockStyle.Top;
			radioButton2.CheckedChanged += radioButtons_CheckedChanged;
			
			radioButton3.Text = "Multiply";
			radioButton3.Dock = DockStyle.Top;
			radioButton3.CheckedChanged += radioButtons_CheckedChanged;
			
			radioButton4.Text = "Divide";
			radioButton4.Dock = DockStyle.Top;
			radioButton4.CheckedChanged += radioButtons_CheckedChanged;
			
			groupBox1.Controls.Add(radioButton4);
			groupBox1.Controls.Add(radioButton3);
			groupBox1.Controls.Add(radioButton2);
			groupBox1.Controls.Add(radioButton1);
			Controls.Add(groupBox1);
		}
		
		void radioButtons_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = sender as RadioButton;
			if (radioButton == null) return;  // Not a radio button
			if (!radioButton.Checked) return; // Radio button isn't checked
				
			// Method 1) Get the Operation from the Tag property
			if (radioButton.Tag is Operation)
			{
				Operation operationFromTag = (Operation)radioButton.Tag;
				Console.WriteLine("From Tag: " + operationFromTag);
			}
			else
			{
				Console.WriteLine("From Tag: (not assigned)");
			}
			
			
			// OR Method 2) Get the Operation from the Dictionary
			Operation operationFromDictionary;
			if (radioButtonToOperation.TryGetValue(radioButton, out operationFromDictionary))
			{
				Console.WriteLine("From Dictionary: " + operationFromDictionary);
			}
			else
			{
				Console.WriteLine("From Dictionary: (not found)");
			}
		}
	}
	public enum Operation
	{
			Add = 1,
			Subtract = 2,
			Multiply = 3,
			Divide = 4
  }
