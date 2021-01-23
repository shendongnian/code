    public interface IQuestion
    {
        public int AnwserToLife { get; set; } //leave out 'set' for read-only
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
