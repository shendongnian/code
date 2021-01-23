    namespace OOPS.Interfaces
    {
        using System.Collections.Generic;
    
        public interface IBanner
        {
            string Name { get; set; }
        }
    
        public interface IBannerContent<T> where T : IBanner
        {
            List<T> Banners { get; set; }
        }
    }
