		using System;
		using System.Collections.Generic;
		using System.ComponentModel;
		using System.Data;
		using System.Drawing;
		using System.Linq;
		using System.Text;
		using System.Windows.Forms;
		namespace winapp
		{
			public partial class Form1 : Form
			{
				public Form1()
				{
					InitializeComponent();
				}
				private void button1_Click(object sender, EventArgs e)
				{
					Form2 frm2 = new Form2();
					frm2.ShowDialog();
				}
			}
	
	
		using System;
		using System.Collections.Generic;
		using System.ComponentModel;
		using System.Data;
		using System.Drawing;
		using System.Linq;
		using System.Text;
		using System.Windows.Forms;
		namespace winapp
		{
			public partial class Form2 : Form
			{
				public Form2()
				{
					InitializeComponent();
				}
			}
		}
