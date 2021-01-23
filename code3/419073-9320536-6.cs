    if (myReader.Read())
    {
       StringBuilder sb = new StringBuilder(myReader.FieldCount);
       for(int i = 0; i<myReader.FieldCount; i++)
       {
          sb.AppendLine(myReader.GetName(i);
       }
       Console.Write(sb.ToString());   
    }
