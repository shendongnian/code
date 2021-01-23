    public class SomeController
    {
        private readonly IDBEntities entities;
        // db context passed in through constructor,
        // to decouple the controller from the backing implementation.
        public void SomeController(IDBEntities entities)
        {
            this.entities = entities;
        }
    }
