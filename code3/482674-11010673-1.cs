    public abstract Task
    {
        public void Perform(Robot theRobot);
    }
    
    public class Cut : Task
    {
        public void Perform(Robot theRobot)
        {
            var knife = theRobot.ToolBeingHeld as Knife;
            if (knife == null) throw new InvalidOperationException("Must be holding a Knife.");
            knife.Use();
            Console.WriteLine(" to cut.");
        }
    }
    
    public abstract class Tool
    {
        public void Use();
        public void PickUp();
        public void PutDown();
    }
    
    public class Knife
    {
        public void Use()
        {
           Console.Write("Used a knife ");
        }
        public void PickUp()
        {
           Console.WriteLine("Wielded a knife.");
        }
        public void PutDown()
        {
           Console.WriteLine("Put down a knife.");
        }
    }
    
    
    public class Robot
    {
        public Robot()
        {
            Tools = new List<Tool>();
        }
    
        public Tool ToolBeingHeld { get; private set; };
        public void PickUp(Tool tool)
        {
            if (ToolBeingHeld != null) ToolBeingHeld.PutDown();
            ToolBeingHeld = tool;
            ToolBeingHeld.PickUp();
        }
        public void PutDown()
        {
            if (ToolBeingHeld != null) ToolBeingHeld.PutDown();
            ToolBeingHeld = null;
        }
    
        public void PerformTask(Task task)
        {
            task.Perform(this);
        }
    }
