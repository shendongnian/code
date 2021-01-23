    // int is a value type
    int i = 0;
    // Prints True for any value of i
    Console.WriteLine(i.GetType() == typeof(int));
    // string is a sealed reference type
    string s = "Foo";
    // Prints True for any value of s
    Console.WriteLine(s == null || s.GetType() == typeof(string));
    // object is an unsealed reference type
    object o = new FileInfo("C:\\f.txt");
    // Prints False, but could be true for some values of o
    Console.WriteLine(o == null || o.GetType() == typeof(object));
    // FileSystemInfo is an abstract type
    FileSystemInfo fsi = new DirectoryInfo("C:\\");
    // Prints False for all non-null values of fsi
    Console.WriteLine(fsi == null || fsi.GetType() == typeof(FileSystemInfo));
