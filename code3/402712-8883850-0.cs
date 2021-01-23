    public interface IQuestion
    {
        public int AnwserToLife { get; set; }
    }
    public class HitchHiker : IQuestion
    {
        public int AnwserToLife
        {
            get
            {
                return 42;
            }
            set
            {  
                //never changes
            }
        }
    }
