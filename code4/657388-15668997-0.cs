        List<DogClass> Dogs = new List<DogClass>();
        string SQL = "select DogId from Dog";
        SqlCommand Command = new SqlCommand(SQL, Con);
        SqlDataReader Reader = Command.ExecuteReader();
        while (Reader.Read())
        {
            DogClass Dog = new DogClass(Reader, Con);
            Dogs.Add(Dog);
        }
        Reader.Close();
----------
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    
    class DogClass
    {
        string DogId;
        List<BreedClass> Breeds = new List<BreedClass>();
    
        internal DogClass(SqlDataReader Reader, SqlConnection Con)
        {
            DogId = Convert.ToString(Reader.GetValue(Reader.GetOrdinal("DogId"))).Trim();
            string SQL = "select BreedOfDog from Breeds where DogID = '" + DogId + "'";
            SqlCommand Command = new SqlCommand(SQL, Con);
            SqlDataReader Reader2 = Command.ExecuteReader();
            while (Reader2.Read())
            {
                BreedClass Breed = new BreedClass(Reader);
                Breeds.Add(Breed);
            }
            Reader2.Close();
        }
    }
