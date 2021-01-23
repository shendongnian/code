    // A sample enemy class
    class Enemy
    {
    	public int EnemyStrength { get; set; }
    
    	public Enemy(int strength)
    	{
    		EnemyStrength = strength;
    	}
    }
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		// A List to hold all the enemies
    		List<Enemy> Enemies = new List<Enemy>();
    
    		// Create some enemies
    		for (int i = 0; i < 5; i++)
    		{
    			Enemies.Add(new Enemy(i));
    		}
    
    		// Display the strength of them all.
    		foreach (Enemy enemy in Enemies)
    		{
    			Console.WriteLine(enemy.EnemyStrength);
    		}
    
    	}
    }
