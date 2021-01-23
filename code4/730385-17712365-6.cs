    public class MamalService : IAnimalService<MamalItem, MamalSearchOptions>
    {
        public SearchResult<MamalItem> SearchForAnimals(MamalSearchOptions searchOptions)
        {
            throw new NotImplementedException();
        }
    }
    
    public class FishService : IAnimalService<Fish, FishSearchOptions>
    {
        public SearchResult<Fish> SearchForAnimals(FishSearchOptions searchOptions)
        {
            throw new NotImplementedException();
        }
    }
