	Random r;
    List<Button> buttons;	
	private void Whack_A_Mole_Load(object sender, EventArgs e)
	{
		r = new Random();
		
		buttons = new List<Button>();
		
		buttons.Add(button1);
		buttons.Add(button2);
		buttons.Add(button3);
		buttons.Add(button4);
		buttons.Add(button5);
		buttons.Add(button6);
		buttons.Add(button7);
		buttons.Add(button8);
		buttons.Add(button9);
		
		for(int i = 0; i < 9; i++)
			buttons[i].Visible = false;
	}
