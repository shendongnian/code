    string sample = "this is \"what I need\"";
    Regex reg = new Regex(@"""(.+)"""); 
    Match mat = reg.Match(sample);
    string foundValue = "";
    if(mat.Groups.Count > 1){
       foundValue = mat.Groups[1].Value;
    }
    Console.WriteLine(foundValue);
