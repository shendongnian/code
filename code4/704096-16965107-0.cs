    string input = "sorrrrrrry";
    Regex regex = new Regex(@"(\w)\1+");
    
    string replacement = "$1$1";
    string res = regex.Replace(input, replacement);
    Console.WriteLine(res);
    //will output => sorry
                
    replacement = "$1";
    res = regex.Replace(input, replacement);
    Console.WriteLine(res);
    //will output => sory
