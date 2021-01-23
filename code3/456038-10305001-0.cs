    var outputs = new List<string>() {
                            "this is output",
                            "this is also output",
                            "output",
                            "my output"
                        };
    
    var size = outputs.Max (str => str.Length) + 5;
    
    Console.WriteLine ( string.Join(Environment.NewLine, outputs.Select (str => str.PadRight( size ) + "Text" ) ));
    
    /*
    this is output          Text
    this is also output     Text
    output                  Text
    my output               Text
    */
