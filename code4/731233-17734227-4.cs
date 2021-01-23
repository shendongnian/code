    string commandStringSObjs = 
    @"
    SELECT Id, ..other attributes... FROM SpectroscopyObject
    ";
    string commandStringCoords = 
    @"
    SELECT XCoord,YCoord,AbsorptionInfo 
    WHERE SpectroscopyObjectId = @Id
    ";
    
    var streoscopicObjs = new List<SpectroscopyObject>();
    using(var connection = new SqlConnection(CONNECTION_STRING))
    {
        using(var cmd = connection.CreateCommand())
        {
            cmd.CommandText = commandStringSObjs;
            connection.Open();
            using(var rdr = cmd.ExecuteReader())
            {
                while(rdr.Read())
                {
     
                    streoscopicObjs.Add(new SpectroscopyObject
                    {
                        Id = Convert.ToInt32(rdr["Id"])
                        //populate your other stuff
                    }
                }
            }
        }
        //to read the absorption info
        foreach(var obj in streoscopicObjs)
        {
            var current = obj.FrequecyAbsorption;
            using(var cmd = connection.CreateCommand())
            { 
                cmd.CommandText = commandStringCoords;
                cmd.Parameters.Add(
                    new SqlParameter("Id",DbType.Int){ Value = obj.Id});
                using(var rdr = cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {
                        var x = Convert.ToInt32(rdr["XCoord"]);
                        var y = Convert.ToInt32(rdr["YCoord"]);
                        var freq = Convert.ToDouble(rdr["AbsorptionInfo"]);
                        
                        current[x][y] = new FrequencyAbsorptionPoint
                        {
                            Location = new Point(x,y),
                            Frequency = freq
                        };
                    }
                }
            }
        }
         
        //do some stuff
        ...
       // assuming you update 
        string updatefreq = 
    @"
    
    
    INSERT INTO FrequencyAbsorptionInfo(XCoord,YCoord,
                       AbsorptionInfo,SpectroscopyObjectId )
    VALUES(@xvalue,@yvalue,@freq,@Id) ";
        //other point already
    
        //to write the absorption info
        foreach(var obj in streoscopicObjs)
        {
            using(var cmd = connection.CreateCommand())
            {
                cmd.CommandText = 
    @"
    DELETE FrequencyAbsoptionInfo 
    WHERE  SpectroscopyObjectId =@Id
    ";
                cmd.Parameters.Add(new SqlParameter("Id",DbType.Int){ Value = obj.Id});
                cmd.ExecuteNonQuery();
            }
            var current = obj.FrequecyAbsorption;
            foreach(var freq in current)
            {
                using(var cmd = connection.CreateCommand())
                { 
                    cmd.CommandText = updatefreq ;
                    cmd.Parameters.AddRange(new[]
                    {
                        new SqlParameter("Id",DbType.Int){ Value = obj.Id},
                        new SqlParameter("XCoords",DbType.Int){ Value = freq.Location.X},
                        new SqlParameter("YCoords",DbType.Int){ Value = freq.Location.Y},
                        new SqlParameter("freq",DbType.Int){ Value = freq.Frequency },
                    });
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
