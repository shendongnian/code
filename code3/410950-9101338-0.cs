    class Program
    {
        static void Main(string[] args)
        {
            var instance = new MyClass();
            instance.Add<int, string>(i => i.ToString());
            instance.Add<string, int>(str => str.Length);
            instance.Add<int, int>(i => i*i);
            Console.WriteLine(instance.Chain(349));
            Console.ReadLine();
              
        }
    }
    public class MyClass
    {
        private IList<Delegate> _Delegates = new List<Delegate>();
        public void Add<InputType, OutputType>(Func<InputType, OutputType> action)
        {
            _Delegates.Add(action);
        }
        public object Chain<InputType>(InputType startingArgument)
        {
            object currentInputArgument = startingArgument;
            for (var i = 0; i < _Delegates.Count(); ++i)
            {
                var action = _Delegates[i];
                currentInputArgument = action.DynamicInvoke(currentInputArgument);
            }
            return currentInputArgument;
        }
    }
