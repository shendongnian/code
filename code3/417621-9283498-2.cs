	public class MyForm : Form
	{
		public MyForm()
		{
			InitializeComponent();
			
			
			// Method 1) The Tag property on any control can be user as user data
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
			Operation? operationFromTag = GetOperationFromTag(radioButton);
			Console.WriteLine("From Tag: " + (operationFromTag == null ? "(none)" : operationFromTag.ToString() ));
			
			// OR Method 2) Get the Operation from the Dictionary
			Operation? operationFromDictionary = GetOperationUsingDictionary(radioButton);
			Console.WriteLine("From Dictionary: " + (operationFromDictionary == null ? "(none)" : operationFromDictionary.ToString()) );
		}
		private Operation? GetOperationFromTag(RadioButton radioButton)
		{
			if (radioButton == null) return null;
			
			if (radioButton.Tag is Operation)
			{
				Operation operationFromTag = (Operation)radioButton.Tag;
				return operationFromTag;
			}
			
			return null;
		}
		
		private Operation? GetOperationUsingDictionary(RadioButton radioButton)
		{
			if (radioButton == null) return null;
			
			Operation operationFromDictionary;
		    return
				radioButtonToOperation.TryGetValue(radioButton, out operationFromDictionary)
				? operationFromDictionary
				: (Operation?)null;
		}
		public Operation? SelectedOperation
		{
			get
			{
				// You must include System.Linq in your using block at the top of the file for the following
				// extension methods to be picked up by the compiler:
				// * Enumerable.OfType<T> is an extension method on IEnumerable. 
				// * Enumerable.SingleOrDefault<T> is an extension method on IEnumerable<T>
				
				RadioButton selectedRadioButton = 
					groupBox1.Controls														// Go through each of the groupbox child controls
						.OfType<RadioButton>()											// Need to convert Controls, which is IEnumerable, to IEnumerable<Control>
						.Where(radioButton => radioButton.Checked)  // Filter through only the checked radio buttons
						.SingleOrDefault();                         // Get the single result, or none. (Exception if there are more than one result)
						
				return GetOperationUsingDictionary(selectedRadioButton);
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
