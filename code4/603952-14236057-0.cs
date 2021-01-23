    public interface ICommand
    {
        int CommandCode { get; set; }
        object Argument1 { get; }
        object Argument2 { get; }
        object Argument3 { get; }
    }
    public static class Command
    {
        public static Command<T1, T2, T3> Create<T1, T2, T3>(int code, T1 arg1, T2 arg2, T3 arg3)
        {
            return new Command<T1, T2, T3>(code, arg1, arg2, arg3);
        }
    }
    public class Command<T1, T2, T3> : ICommand
    {
        public Command(int code, T1 arg1, T2 arg2, T3 arg3)
        {
            CommandCode = code;
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
        }
        public int CommandCode { get; set; }
        public T1 Argument1 { get; set; }
        public T2 Argument2 { get; set; }
        public T3 Argument3 { get; set; }
        object ICommand.Argument1
        {
            get { return Argument1; }
        }
        object ICommand.Argument2
        {
            get { return Argument2; }
        }
        object ICommand.Argument3
        {
            get { return Argument3; }
        }
    }
