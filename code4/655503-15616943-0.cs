    public abstract class Enemy
    {
    	public abstract int KillPoints {get;}
    }
    
    public class EnemyTeleport : Enemy
    {
    	public override int KillPoints
    	{
    		get{return 6;}
    	}
    }
    
    public class EnemyZigZag : Enemy
    {
    	public override int KillPoints
    	{
    		get{return 10;}
    	}
    }
