        public enum EntityType
        {
            Address,
            Department
        }
    
        public class UserController : ApiController
        {
            public IEnumerable<Category> Categories(EntityType entity, string property)
            {
            }
        }
    You'll still need code to do something with the entity type, but that seems safer than letting the client send you random CLR type names? And then the model binding will validate the {entity} segment in the URI. So if a client requests User/Categories/FavoriteBeer, they will get 400, Bad Request.
