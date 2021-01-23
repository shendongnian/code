     public static string GetPassword()
     {
    string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
     Random rnd = new Random();
    int index = rnd.Next(0,51);
    string char1 = Characters[index].ToString();
    return char1;
      }
    
