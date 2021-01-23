    using System;
    using System.Data.SqlClient;
    
    class BreedClass
    {
        internal string Breed;
    
        internal BreedClass(SqlDataReader Reader)
        {
            Breed = Convert.ToString(Reader.GetValue(Reader.GetOrdinal("BreedOfDog"))).Trim();
        }
    }
