    private void MouseProcess()
	{
		MouseState mstate = Mouse.GetState();
		Mouse_pos = new Vector2(mstate.X, mstate.Y);
		float xpos = mstate.X;
		float ypos = mstate.Y;
		
		if (mstate.LeftButton.Equals(ButtonState.Pressed))
		{
			for (int i=0; i<3; i++)
			{
				if (xpos >= Gamevar[i].Position.X && xpos <= Gamevar[i].Position.X + 72)
				{
					C = i;
				}
				if (ypos >= Gamevar[i*3].Position.Y && ypos <= Gamevar[i*3].Position.Y + 75)
				{
					R = i;
				}
			}
		}
	}
    private void Turncode()
	{
		if (turn==true)
		{
			Gamevar[(R*3)+C].owner=1;
		}
		else
		{
			Gamevar[(R*3)+C].owner=2;
		}
		turn=!turn; //toggle to the other person's turn
		C=0;
		R=0;
	}
