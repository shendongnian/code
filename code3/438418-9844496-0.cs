		private void buttonClick(object sender, EventArgs e)
		{
			Button clicked = (Button) sender;
			ChooseAction(clicked.Name);
		}
		private void ChooseAction(string buttonName)
		{
			switch(buttonName)
			{
				case "button1": doAction1(); break;
				case "button2": doAction2(); break;
				case "button3": doAction3(); break;
				case "button4": doAction4(); break;
				case "button5": doAction5(); break;
				default: doDefaultAction(); break;
			}
		}
		
		private void doAction1()
		{
			Console.WriteLine("action 1");
		}
		
		private void doAction2()
		{
			Console.WriteLine("action 2");
		}
		private void doAction3()
		{
			Console.WriteLine("action 3");
		}
		private void doAction4()
		{
			Console.WriteLine("action 4");
		}
		private void doAction5()
		{
			Console.WriteLine("action 5");
		}
		
		private void doDefaultAction()
		{
			Console.WriteLine("button name not recognised, performing default action");
		}
