    public class Player{}
	
	public static class Logic
	{
		public static readonly Action<Player> PAY_DAY = p => Console.WriteLine( "Pay day : " + p.ToString());
		
		public static readonly Action<Player> COLLECT_CASH = p=> Console.WriteLine(p.ToString ());
	
		public static void AcceptPlayer( this Player ActingPlayer, Action<Player> PlayerAction )
		{
			PlayerAction(ActingPlayer);
		}
	}
	
	class MainClass
	{
		public static void Main (string[] args)
		{
			var player = new Player();
			
			player.AcceptPlayer( Logic.PAY_DAY );
		}
	}
