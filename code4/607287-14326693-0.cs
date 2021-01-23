    string value = "122312121|test value||test value 2|5GOdNF7Q5fK5O9QKiZefJEfO1YECcX1w|123456789|123456789";
    string[] split = value.Split('|');
    
    string begin = string.Join("|", split.Take(4));
    string middle = split.Skip(4).Take(1).FirstOrDefault();
    string end = "|" + string.Join("|", split.Skip(5).Take(2));
