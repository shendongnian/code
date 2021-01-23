	namespace YourProjectNamespace
	{
		class SomeOtherClass
		{
			// Declare and Assign
			dataGlobal dataLocal = Form1.dataMain;
			public void SomethingToDo()
			{
				dataLocal.txtConsole.Visible = true;
				dataLocal.txtConsole.Text = "Typing some text into Form1's TextBox1" + "\r\n";
				dataLocal.txtConsole.AppendText("Adding text to Form1's TextBox1" + "\r\n");
				string retrieveTextBoxValue = dataLocal.txtConsole.Text;
				// Your own code continues...
			}
		}
	}
  
