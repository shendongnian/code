    namespace MyLevel
    {
        public class Default : IDefault
        {
            
        }
    
        public interface IDefault
        {
            IEnumerable<DefaultCore> GetDefaultValues();            
        }
    }
