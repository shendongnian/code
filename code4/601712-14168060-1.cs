    FileStream fs;
    fs = File.OpenWrite(@"C:\blah.dat");
    BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8);
    bw.Write((int)12345678);
    bw.Write("This is a string in UTF-8 :)"); // Note that the binaryWriter also prefix the string with its length...
    bw.Close();
    fs = File.OpenRead(@"C:\blah.dat");
    BinaryReader br = new BinaryReader(fs, Encoding.UTF8);
    int myInt = br.ReadInt32();
    string blah = br.ReadString(); // ...so that it can read it back.
    br.Close();
