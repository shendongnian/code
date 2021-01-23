    var input = "aabbbffdshhh";
    
    var characters = input.ToArray();
    
    StringBuilder sb = new StringBuilder();
    characters.ToList().ForEach(c=>{if(!sb.ToString().Contains(c)){sb.Append(c); sb.Append(characters.ToList().Count(cc=>cc == c));}});
    
    //sb.ToString().Dump(); //output is a2b3f2d1s1h3
