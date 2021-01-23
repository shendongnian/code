	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Forms;
	namespace WindowsFormsApplication1
	{
		public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
				textBox1.KeyUp += textBox_Compare;
				textBox2.KeyUp += textBox_Compare;
			}
			private void textBox_Compare(object sender, KeyEventArgs e)
			{
				Color cBackColor = Color.Red;
				if (textBox1.Text == textBox2.Text)
				{
					cBackColor = Color.Green;
				}
				textBox1.BackColor = cBackColor;
				textBox2.BackColor = cBackColor;
			}
		}
	}
