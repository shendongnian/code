	private void timer1_Tick(object sender, EventArgs e) {
		timer2.Enabled=false;
		timer1.Enabled=false;
		lblTimer_Value_InBuildings.Text="0";
	}
	private void timer2_Tick(object sender, EventArgs e) {
		lblTimer_Value_InBuildings.Text=(int.Parse(lblTimer_Value_InBuildings.Text)+1).ToString();
	}
	private void timer3_Tick(object sender, EventArgs e) {
		if(0!=(int)timer3.Tag) {
			// your code goes here and peformed per step
			timer1.Enabled=true;
			timer2.Enabled=true;
		}
		timer3.Tag=(1+(int)timer3.Tag)%Max_Step;
	}
