    public class HeroRepository : IRepository<Heros> where T : class, IMongoEntity
    {
        // ...
    
        public IQueryable<Heros> Heros 
        {
            get 
            { 
                return _ctx.GetCollection<Heros>().AsQueryable(); 
                // Careful there, doing this from memory, may be a little off...
            }
        }
    }
