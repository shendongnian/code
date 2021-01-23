    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    namespace MvcDemo.Models
    {
    public class Color
    {
        
            public int ID { get; set; }
            public Boolean Red { get; set; }
            public Boolean Blue { get; set; }
        
    }
    public class ColorContext : DbContext
    {
        public DbSet<Color> Colors
        {
            get;
            set;
        }
    }
    }
