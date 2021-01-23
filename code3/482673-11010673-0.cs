    public abstract Task
    {
        public void Perform(Robot theRobot);
    }
    
    public class Cut : Task
    {
        public void Perform(Robot theRobot)
        {
            var knife = theRobot.Tools.OfType<Knife>().FirstOrDefault();
            if (knife == null) throw new InvalidOperationException("Must be holding a Knife.");
            knife.Use();
            Console.WriteLine(" to cut.");
        }
    }
    
    public abstract class Tool
    {
        public void Use();
    }
    
    public class Knife
    {
        public void Use()
        {
           Console.Write("Used a knife ");
        }
    }
    
    
    public class Robot
    {
        public Robot()
        {
            Tools = new List<Tool>();
        }
    
        public List<Tool> Tools { get; private set; }
    
        public void PerformTask(Task task)
        {
            task.Perform(this);
        }
    }
    var robot = new Robot();
    robot.Tools.Add(new Knife());
    robot.Perform(new Cut()); // output is "Used a knife to cut."
