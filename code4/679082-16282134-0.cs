    string example = Encoding.ASCII.GetString(exampleArray);
    string delimiter = Encoding.ASCII.GetString(new byte[] { 0x13, 0x10 });
    string[] result = example.Split(new string[] { delimiter});
    string ending = Encoding.ASCII.GetString(new byte[] { 0x75, 0x3a, 0x13 });
    bool ends = example.EndWith(ending);
