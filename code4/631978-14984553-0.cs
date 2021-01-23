    string test = "%%x%%a,b,c,d";
    string[] result = test.Split(new char[] { '%', ',' }, StringSplitOptions.RemoveEmptyEntries);
    foreach (string s in result) {
      Console.WriteLine(s);
    }
