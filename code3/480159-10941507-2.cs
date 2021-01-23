    var s1 = "é"; //é as one character (ALT+0233)
    var s2 = "é"; //'e', plus combining acute accent U+301 (two characters)
    
    Console.WriteLine(s1.IndexOf(s2, StringComparison.Ordinal)); //-1
    Console.WriteLine(s1.IndexOf(s2, StringComparison.InvariantCulture)); //0
    Console.WriteLine(s1.IndexOf(s2, StringComparison.CurrentCulture)); //0
