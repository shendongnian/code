    public abstract class BasePoster { }
    public class PetPoster : BasePoster { }
    public class FlowerPoster : BasePoster { }
    // NOTE the out keyword here.
    public interface IPosterGenerator<out T> where T : BasePoster
    {
        IQueryable<T> GetPosters();
    }
    public class PetPosterGenerator : IPosterGenerator<PetPoster>
    {
        public IQueryable<PetPoster> GetPosters()
        {
            return Enumerable.Range(0, 5).Select(i =>
            {
                return new PetPoster();
            }).AsQueryable();
        }
    }
    public class FlowerPosterGenerator : IPosterGenerator<FlowerPoster>
    {
        public IQueryable<FlowerPoster> GetPosters()
        {
            return Enumerable.Range(0, 5).Select(i =>
            {
                return new FlowerPoster();
            }).AsQueryable();
        }
    }
    public class PinBoard
    {
        protected List<IPosterGenerator<BasePoster>> PosterGenerators
        {
            get;
            private set; // fixes compiler warning #1
        }
        public PinBoard(List<IPosterGenerator<BasePoster>> generators) // specify the generic type, fixes compiler warning #2
        {
            this.PosterGenerators = generators;
        }
        public List<BasePoster> GetPosters()
        {
            var posters = new List<BasePoster>();
            foreach (var generator in PosterGenerators)
            {
                posters.AddRange(generator.GetPosters()); // call AddRange not Add
            }
            return posters;
        }
    }
