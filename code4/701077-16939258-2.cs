    	void btn_MouseEnter(object sender, MouseEventArgs e)
		{	
            DoubleAnimation animation = 
            	new DoubleAnimation(1.0, 0.5, new Duration(TimeSpan.FromSeconds(.5)));
            btn.ApplyAnimationClock(Button.OpacityProperty, animation.CreateClock());  		
		}
