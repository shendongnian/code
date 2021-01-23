	public void BaseWeapon ChangeButtonColor(Color thisColor, params Button[] buttons)
	{
		foreach (Button thisButton in buttons)
		{
			thisButton.BackColor = thisColor
		}
	}
