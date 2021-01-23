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
