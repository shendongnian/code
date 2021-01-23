    public class CommandInfo
    {
        public string Name { get; set; }
        public Action<RunArgument> Action { get; set; }
    }
    
    public class MyClass
    {
        public List<CommandInfo> Commands;
    
        public MyClass 
        {
            Commands = new List<CommandInfo>
            {
                new CommandInfo { Name = "abc", Action = AbcAction }
            };
        }
    
        public void AbcAction(RunArgument arg)
        {
            ; // Do something useful here
        }
    }
