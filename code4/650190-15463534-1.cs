    namespace StartReg.Data {
        using System;
        using System.Collections.Generic;
        using System.Data.Entity;
        using System.Data.Entity.Infrastructure;
        using System.Linq;
        
        public partial class StartRegDb : DbContext {
            public StartRegDb()
                : base("DefaultConnection") {
            }
        
            public DbSet<Distance> Distances { get; set; }
        }
    }
