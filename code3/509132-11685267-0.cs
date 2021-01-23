    for (int i = 0; i < 4; i++)
    {
        if (!objReader.IsDBNull(i))
            sw.Write(objReader.GetValue(i).ToString());
        else
            sw.Write("NULL");
        if (i < 3) 
            sw.Write("\t");
    }
    count += 1;
    sw.WriteLine();
