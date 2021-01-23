    public abstract class Task
    {
    	public abstract void Perform(Robot theRobot);
    }
    
    public class Cut : Task
    {
    	public string What { get; private set; }
    
    	public Cut(string what)
    	{
    	   What = what;
    	}
    
    	public override void Perform(Robot theRobot)
    	{
    		var knife = theRobot.ToolBeingHeld as Knife;
    		if (knife == null) throw new InvalidOperationException("Must be holding a Knife.");
    		knife.Use(theRobot);
    		Console.WriteLine("to cut {0}.", What);
    	}
    }
    public class Stab : Task
    {
        public override void Perform(Robot theRobot)
        {
             var knife = theRobot.ToolBeingHeld as Knife;
             if (knife == null) throw new InvalidOperationException("Must be holding a Knife.");
      
             knife.Use(theRobot);
             Console.WriteLine("to stab.");
        }
    }
    public class Bore : Task
    {
        public override void Perform(Robot theRobot)
        {
             var drill = theRobot.ToolBeingHeld as Drill;
             if (drill == null) throw new InvalidOperationException("Must be holding a Drill.");
             drill.Use(theRobot);
             Console.WriteLine("to bore a hole.");
        }
    }
    
    public abstract class Tool
    {
    	public abstract void Use(Robot theRobot);
    	public abstract void PickUp(Robot theRobot);
    	public abstract void PutDown(Robot theRobot);
    }
    
    public class Knife : Tool
    {
    	public Knife(string kind)
    	{
    		Kind = kind;
    	}
    
    	public string Kind { get; private set; }
    
    	public override void Use(Robot theRobot)
    	{
    	   Console.Write("{0} used a {1} knife ", theRobot.Name, Kind);
    	}
    
    	public override void PickUp(Robot theRobot)
    	{
    	   Console.WriteLine("{0} wielded a {1} knife.", theRobot.Name, Kind);
    	}
    
    	public override void PutDown(Robot theRobot)
    	{
    	   Console.WriteLine("{0} put down a {1} knife.", theRobot.Name, Kind);
    	}
    }
    
    public class Drill : Tool
    {    
    	public override void Use(Robot theRobot)
    	{
    	   Console.Write("{0} used a drill ", theRobot.Name);
    	}
    
    	public override void PickUp(Robot theRobot)
    	{
    	   Console.WriteLine("{0} picked up a drill.", theRobot.Name);
    	}
    
    	public override void PutDown(Robot theRobot)
    	{
    	   Console.WriteLine("{0} put down a drill.", theRobot.Name);
    	}
    }
    
    public class Robot
    {
    	public Robot(string name)
    	{
    		Name = name;
    	}
    
    	public string Name { get; private set; }
    
    	public Tool ToolBeingHeld { get; private set; }
    
    	public void PickUp(Tool tool)
    	{
    		if (ToolBeingHeld != null) ToolBeingHeld.PutDown(this);
    
    		ToolBeingHeld = tool;
    
    		ToolBeingHeld.PickUp(this);
    	}
    
    	public void PutDown()
    	{
    		if (ToolBeingHeld != null) ToolBeingHeld.PutDown(this);
    		ToolBeingHeld = null;
    	}
    
    	public void Perform(Task task)
    	{
    		task.Perform(this);
    	}
    }
