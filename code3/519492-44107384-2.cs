    namespace OOPS.Complex
    {
        using Interfaces;
        using System.Collections.Generic;
    
        public class Banner : IBanner
        {
            public string Name { get; set; }
    
            public string Description { get; set; }
        }
    
        public class BannerContent : IBannerContent<Banner>
        {
            public List<Banner> Banners { get; set; }
        }
    }
