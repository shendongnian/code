    class Mole
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int Counter { get; set; }
		public Control Image { get; set; }
		public bool IsNew { get; set; }
	}
	class Test
	{	
		IList<Mole> moles = new List<Mole>();
		
		private static void AddSomeMoles()
		{
			moles.Add(new Mole{ X = rand.Next(100), Y = rand.Next(100), Counter = 3, Image = new PictureBox(), IsNew = true });
		}
		
		private static void DisplayMoles()
		{
			foreach (Mole mole in moles)
			{
				if (mole.IsNew)
				{
					grid_Main.Children.Add(mole.Image);
					mole.IsNew = false;
				}
			}
		}
		
		private static void CleanupMoles()
		{
			foreach (Mole mole in moles)
			{
				mole.Counter -= 1;
				
				if (mole.Counter <= 0)
				{
					grid_Main.Children.Remove(mole.Image);
					moles.Remove(mole);
				}
			}
		}
		
		static void Main()
		{	
			while (true)
			{
				AddSomeMoles();
				DisplayMoles();
				
				Thread.Sleep(1000);
				
				CleanupMoles();
			}
		}
	}
