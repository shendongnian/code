    using MvcMovie.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    
    namespace MvcMovie.Models
    {
        public class MovieDBContext : DbContext
        {
            public DbSet<Movie> Movies { get; set; }
        }
    }
