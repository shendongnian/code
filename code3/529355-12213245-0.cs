	interface IComponent
	{
	}
	class unit : IComponent
	{
		//...
	}
	class enemy : IComponent
	{
		//...
	}
	class gameObject
	{
		IComponent component;//now only objects inheriting IComponent can be assigned here
		
		public void DrawComponent()
		{
			unit u = component as unit;
			if (u != null) {
				u.Draw();
			}
			enemy e = component as enemy;
			if (e != null) {
				e.DrawIfVisible();
			}
		}
	}
