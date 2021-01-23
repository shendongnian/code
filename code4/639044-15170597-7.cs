	// Hah - artificial difficulty due
	// to awkward key choice? Out of curiosity,
	// why not Keys.Up, Down, Left, Right?
	if (e.KeyCode == Keys.E)
	{
		_objDirection = Direction.Left;
	}
	else if (e.KeyCode == Keys.D)
	{
		_objDirection = Direction.Right;
	}
	else if (e.KeyCode == Keys.W)
	{
		_objDirection = Direction.Up;
	}
	else if (e.KeyCode == Keys.S)
	{
		_objDirection = Direction.Down;
	}
	// same deal here, but with keys
        // Or switch to Up, Down, Left, Right :)
	switch (e.KeyCode)
	{
		case Keys.E: 
			_objDirection = Direction.Up;
			break;
		case Keys.D:
			_objDirection = Direction.Down;
			break;
		case Keys.W:
			_objDirection = Direction.Left;
			break;
		case Keys.S:
			_objDirection = Direction.Right;
			break;
	}
