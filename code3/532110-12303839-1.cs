    FileStream fs = File.Create(fname.Groups[1].Value, SOME_SIZE, FileOptions.None))
    BinaryFormatter formatter = new BinaryFormatter();
    ...
    //inside your loop
    string s = parts[i];
    formatter.Serialize(fs, Encoding.Unicode.GetBytes(s));
    
