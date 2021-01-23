    string s;
    try {
      Fjuk(out s);
      Console.WriteLine(s); // here the variable is guaranteed to be set
    } catch (Exception) {
      Console.WriteLine(s); // here it's not, so this won't compile
    }
