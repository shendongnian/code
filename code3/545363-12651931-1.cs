    if (reader.HasRows)
    {
         int data1Index = reader.GetOrdinal("data1");
         int data2Index = reader.GetOrdinal("data2");
         while (reader.Read())
         {
             string data1 = reader.GetString(data1index);
             string data2 = reader.GetString(data2index);
             list.Add(cod_aeroport);
             list.Add(data1);
             list.Add(data2);
         }
    }
