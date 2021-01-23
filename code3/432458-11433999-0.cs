    public class NullToZeroEventListener : AuditEventListener, IPreInsertEventListener, IPreUpdateEventListener
    {
        public bool OnPreInsert(PreInsertEvent @event) {
            ZeroNullIds(@event.State, @event.Persister.PropertyNames);
            return false;
        }
        public bool OnPreUpdate(PreUpdateEvent @event) {
            ZeroNullIds(@event.State, @event.Persister.PropertyNames);
            return false;
        }
        protected internal void ZeroNullIds(Object[] state, string[] propertyNames) {
            for(int i = 0; i < propertyNames.Length; i++) {
                if(state[i] != null || propertyNames[i].EndsWith("ID")) continue;
                state[i] = 0;
            }
        }
    }
