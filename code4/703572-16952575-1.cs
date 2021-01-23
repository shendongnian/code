    public class AdventurerViewModel : IEntityViewModel<Adventurer>
    {
        public void SetCurrentEntity(Adventurer entity)
        {
            // Do what you need to with the entity - depending on your needs, 
            // you might keep it intact in case editing is cancelled, and just
            // work on a copy.
        }
    }
