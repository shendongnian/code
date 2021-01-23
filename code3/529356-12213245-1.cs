	interface IDrawable
	{
		void Draw();
	}
	class unit : IDrawable
	{
		public void Draw(){;}
		//...
	}
	class enemy : IDrawable
	{
		public void Draw(){;}
		//...
	}
	class gameObject
	{
		IDrawable component;
		
		public void DrawComponent()
		{
			//now you don't need to care what type component really is
			//it has to be IDrawable to be assigned to test
			//and because it is IDrawable, it has to have Draw() method
			if (component != null) {
				component.Draw();
			}
		}
	}
