    public class PinBoard
    {
        protected List<IPosterGenerator<BasePoster>> PosterGenerators { get; set; }
    
        public PinBoard(List<IPosterGenerator<BasePoster>> generators)
        {
            this.PosterGenerators = generators;
        }
    
        public List<BasePoster> GetPosters()
        {
            var posters = new List<BasePoster>();
    
            foreach (var generator in PosterGenerators)
            {
                posters.Add(generator.GetPosters());
            }
    
            return posters;
        }
    }
