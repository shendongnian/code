	namespace ConsoleApplication1
	{
		class Program
		{
			private static int level = 0;
			private static int xp = 0;
			static void Main(string[] args)
			{
				AdvancePreLvlThree();
			}
			static bool AdvancePreLvlThree() // advances player to next level when level is less than three
			{
				if(level == 1)
				{
					xp = (xp - 100); // carries remaining xp over to next level
				}
				else if(level == 2)
				{
					xp = (xp - 150);
				}
				level +=1; // advances
				return Update(); // checks again to see if they can advance further
			}
			static bool Update()
			{
				// Yes they can...
				return true;
			}
		}
	}
