    public class StatePersistenceStateEntryConverter : CustomCreationConverter<IStateEntry>
    {
        public override IStateEntry Create(Type objectType)
        {
            if (objectType == typeof(IPrecommitStateEntry))
            {
                return new PrecommitStateEntry();
            }
            else
            {
                return new StateEntry();
            }
        }
    }
