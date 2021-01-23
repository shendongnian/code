    //this is the reciever
    class Calculator : IReciever
    {
        public int X { get; set; }
        public int Y { get; set; }
    
        public Calculator(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        
        public int Calculate(int commandOption)
        {
            Command command = new CommandFactory().GetCommand(commandOption);
            return command.Execute();
        }
    }
    
    
    //command
    abstract class Command
    {
        protected IReciever reciever;
    
        public Command(IReciever reciever)
        {
            this.reciever = reciever;
        }
    
        public abstract int Execute();
    }
    
    class AddCommand : Command
    {
        public AddCommand(IReciever reciever) : base(reciever)
        {
        }
    
        public override int Execute()
        {
            return reciever.X + reciever.Y;
        }
    }
    
    class AddCommand : Command
    {
        public AddCommand(IReciever reciever) : base(reciever)
        {
        }
    
        public override int Execute()
        {
            return reciever.X * reciever.Y;
        }
    }
    
    interface IReciever
    {
    	int X {get; set;}
    	int Y {get; set;}
        int Calculate(int commandOption);
    }
    
    public class CommandFactory
    {
    	public GetCommand(int commandOption)
    	{
            switch(commandOption)
            {
                case 1:
                    return new AddCommand(reciever);
                case 2:
                    return new SubtractCommand(reciever);
                case 3:
                    return new MultiplyCommand(reciever);
                default:
                    return new AddCommand(reciever);
            }		
    	}
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            IReciever reciever = new Calculator(500, 25);
            //#Issue:The SetAction() method of the reciever is accessible.
            //reciever.SetAction(CommandOptions.ADD);
            
		//Reciever no longer exposes SetAction
        //reciever.SetAction(CommandOptions.MULTIPLY);
        Console.Write("Enter option 1-3: ");
        int commandOption = int.Parse(Console.ReadLine());
        
        Console.WriteLine(reciever.Calculate(commandOption));
        Console.ReadKey();
    }
}
