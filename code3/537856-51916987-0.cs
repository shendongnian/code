    Console.WriteLine("2D Array");
    String[,] array2d = new String[,] { { "A1", "B1" }, { "A2", "B2" } };
    foreach(var s in array2d.Cast<String>())
    	Console.Write(s + ", ");
    
    Console.WriteLine("\r\n3D Array");
    String[,] array3d = new String[,] { { "A1", "B1", "C1" }, { "A2", "B2", "C1" } };
    foreach (var s in array3d.Cast<String>())
    	Console.Write(s + ", ");
