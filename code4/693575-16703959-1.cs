    public class FSMSystem<T> : MonoBehaviour where T : FSMSystem<T>
    {
        private T m_Owner = default(T);
        protected FSMState<T> currentState;
        private Dictionary<int, FSMState<T>> m_states;
        public FSMSystem()
        {
            m_Owner = this as T;
            m_states = new Dictionary<int, FSMState<T>>();
        }
        protected void AddState( FSMState<T> state )
        {
            m_states.Add( state.GetStateID(), state );
        }
    }
    public abstract class FSMState<T> where T : FSMSystem<T>
    {
        public abstract int GetStateID();
	
        public abstract void OnEnter (T fsm, FSMState<T> prevState);
        public abstract void OnUpdate (T fsm);
        public abstract void OnExit (T fsm, FSMState<T> nextState);
    }
