	namespace YourProjectNamespace
	{
		class SomeOtherClass
		{
			public void SomethingToDo()
			{
				Form1.txtConsole.Visible = true;
				Form1.txtConsole.Text = "Typing some text into Form1's TextBox1" + "\r\n";
				Form1.txtConsole.AppendText("Adding text to Form1's TextBox1" + "\r\n");
				string retrieveTextBoxValue = Form1.txtConsole.Text;
				// Your own code continues...
			}
		}
	}
	
