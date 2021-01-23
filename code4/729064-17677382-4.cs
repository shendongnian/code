    public class Apply<T>
    {
        private Action<T> _action;
    
        public Apply(Action<T> action) { _action = action; }
    
        public static Apply<T> Method(Action<T> actionToCarryOut)
        {
            return new Apply<T>(actionToCarryOut);
        }
        public void To(params T[] listOfThings)
        {
            foreach (var thing in listOfThings)
            {
            	_action(thing);
            }
        }
        
    }
