	public class KbHandler
	{
		private Keys[] lastPressedKeys;
		public KbHandler()
		{
			lastPressedKeys = new Keys[0];
		}
		public void Update()
		{
			KeyboardState kbState = Keyboard.GetState();
			Keys[] pressedKeys = kbState.GetPressedKeys();
			//check if any of the previous update's keys are no longer pressed
			foreach (Keys key in lastPressedKeys)
			{
				if (!pressedKeys.Contains(key))
					OnKeyUp(key);
			}
			//check if the currently pressed keys were already pressed
			foreach (Keys key in pressedKeys)
			{
				if (!lastPressedKeys.Contains(key))
					OnKeyDown(key);
			}
			//save the currently pressed keys so we can compare on the next update
			lastPressedKeys = pressedKeys;
		}
		private void OnKeyDown(Keys key)
		{			
			//do stuff
		}
		private void OnKeyUp(Keys key)
		{
			//do stuff
		}
	}
