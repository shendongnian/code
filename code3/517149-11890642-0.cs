    var name = new CommonData<string>();
    name.Value = "abcd";
    var version = new CommonData<float>();
    version.Value = 2.0F;
    Console.WriteLine("generic object storing string val : {0}", name.Value);
    Console.WriteLine("generic object storing float val : {0}", version.Value);
