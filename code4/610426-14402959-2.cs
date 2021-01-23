    class Program
        {
            static void Main(string[] args)
            {
                var coll = new StateCollection();
                var state = new SomeState();
                coll.AddState(state);
                Console.ReadKey();
            }
        }
    
        public class StateCollection
        {
            private List<IStateBase<IView>> _states = new List<IStateBase<IView>>();
    
            public void AddState(IStateBase<IView> state)
            {
                _states.Add(state);
            }
        }
    
        public class SomeState : StateBase<SomeView>
        {
        }
    
        public class SomeView : IView
        {
        }
    
        public interface IStateBase<out T> where T : IView
        {
            T View { get; }
        }
    
        public abstract class StateBase<T> : IStateBase<T> where T : IView
        {
            public T View { get; set; }
        }
    
        public interface IView
        {
        }
