	ArrowsPressed arrowsPressed;
	void ChangeArrowsState(ArrowsPressed changed, bool isPressed)
	{
		if (isPressed)
		{
			arrowsPressed |= changed;
		}
		else
		{
			arrowsPressed &= ArrowsPressed.All ^ changed;
		}
	}
