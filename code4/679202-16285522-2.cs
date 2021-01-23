	using System;
	using System.Collections.Specialized;
	using System.Configuration;
	...
	...
	...
	
	private void button1_Click(object sender, EventArgs e)
	{
		AppSettingsReader reader = new AppSettingsReader();
		string txtFilePath  = (string)reader.GetValue("txtFilePath", typeof(string));
		
		//string sqlConnectionString = @"C:\Jaspreet_Files\LoadOrgInPortal.txt";
		string sqlConnectionString = txtFilePath;
		//var fileContents = System.IO.File.ReadAllText(@"C:\Jaspreet_Files\LoadOrgInPortal.txt");
		var fileContents = System.IO.File.ReadAllText(txtFilePath);
		fileContents = fileContents.Replace("{param_1}", textBox1.Text.ToString());
		fileContents = fileContents.Replace("{param_2}", textBox2.Text.ToString());
		fileContents = fileContents.Replace("{param_3}", textBox3.Text.ToString());
		fileContents = fileContents.Replace("{param_4}", textBox4.Text.ToString());
		System.IO.File.WriteAllText(@"C:\Jaspreet_Files\NewLoadOrgInPortal.txt", fileContents);
		Application.Exit();
	}
