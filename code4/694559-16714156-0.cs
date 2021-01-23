	using System;
	using System.Drawing;
	using System.Windows.Forms;
	namespace WindowsFormsApplication1
	{
		public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
			}
			private void Form1_Load(object sender, EventArgs e)
			{
				CreateButton();
			}
			private void CreateButton() 
			{
				// Add two group boxes
				for (int groupCount = 1; groupCount < 3; groupCount++)
				{
					var groupBox = new GroupBox();
					groupBox.Location = new Point(220 * (groupCount - 1), 10);
					groupBox.Name = string.Format("groupBox{0}", groupCount);
					groupBox.Text = string.Format("Group Box {0}", groupCount);
					// Add some radio buttons to each
					for (int buttonCount = 1; buttonCount < 6; buttonCount++)
					{
						var radioButton = new RadioButton();
						radioButton.Width = 150;
						radioButton.Location = new Point(10, 30 * buttonCount);
						radioButton.Appearance = Appearance.Button;
						radioButton.Name = string.Format("radioButton{0}", buttonCount);
						radioButton.Text = string.Format("Dynamic Radio Button {0} - {1}", groupCount, buttonCount);
						radioButton.CheckedChanged += radioButton_CheckedChanged;
						
						// Add radio button to the group box
						groupBox.Controls.Add(radioButton);
						groupBox.Height += 20;
					}
					// Add group box to form
					Controls.Add(groupBox);
				}               
			}
			private void radioButton_CheckedChanged(object sender, EventArgs e)
			{
				// Get button and only show the selected (not now de-selected item)
				var radioButton = (RadioButton)sender;
				if (radioButton.Checked)
				{
					MessageBox.Show("You have just checked: " + radioButton.Text);
				}
			}
		}
	}
