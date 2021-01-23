    //this is the reciever
    class Calculator : IReciever
    {
        int y;
        int x;
    
        public Calculator(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        public int Calculate(int commandOption)
        {
            Command command = new CommandFactory().GetCommand(commandOption);
            return command.Execute(x , y);
        }
    }
    
    
    //command
    interface ICommand
    {    
        int Execute(int x, int y);
    }
    
    class AddCommand : Command
    {
        public override int Execute(int x, int y)
        {
            return x + y;
        }
    }
    
    class MultiplyCommand : Command
    {
        public override int Execute(int x, int y)
        {
            return x * y;
        }
    }
    
    class SubtractCommand : Command
    {
        public override int Execute(int x, int y)
        {
            return x - y;
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
                    return new AddCommand();
                case 2:
                    return new SubtractCommand();
                case 3:
                    return new MultiplyCommand();
                default:
                    return new AddCommand();
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
