    public class ReflectionLayoutPattern : PatternLayout
    {
        public ReflectionLayoutPattern()
        {
            this.AddConverter("item", typeof(ReflectionReader));
        }
    }
