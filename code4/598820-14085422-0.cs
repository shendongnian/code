	private void P_MouseUp(object sender, MouseEventArgs e) {
		timer1.Enabled=false;
	}
	private void P_MouseDown(object sender, MouseEventArgs e) {
		timer1.Enabled=true;
	}
	private void timer1_Tick(object sender, EventArgs e) {
		if(P.Location.Y>0)
			P.Location=new System.Drawing.Point(P.Location.X, P.Location.Y-1);
	}
