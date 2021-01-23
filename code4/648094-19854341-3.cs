    public class StatePersistenceUserInteractionConverter : CustomCreationConverter<IUserInteraction>
    {
        public override IUserInteraction Create(Type objectType)
        {
            return new UserInteraction();
        }
    }
