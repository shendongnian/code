	static class Scripts
	{
		public static async void AttackPlayer(IGameEngine g)
		{
			await g.Wait(60);
			while(true)
			{
				await DoSomeLogic(g);
				await g.Wait(30);
			}
		}
		private static async Task DoSomeLogic(IGameEngine g)
		{
			SomethingHappening();
			await g.Wait(10);
			SomethingElseHappens();
		}
		private static void ShootAtPlayer()
		{
			Console.WriteLine("Pew Pew!");
		}
		private static void SomethingHappening()
		{
			Console.WriteLine("Something happening!");
		}
		private static void SomethingElseHappens()
		{
			Console.WriteLine("SomethingElseHappens!");
		}
	}
