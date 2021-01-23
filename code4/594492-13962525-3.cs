    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;
    
    namespace YourNamespace.Models
    {
        public class YourDBContext: DbContext
        {
             public DbSet<YourModel> YourModels { get; set; }
        }
    }
