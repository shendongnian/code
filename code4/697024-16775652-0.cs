    string strMy = "5&6";
    char[] arr = strMy.ToCharArray();
    List<int> list = new List<int>();
    foreach (char item in arr)
    {
      int value;
      if (int.TryParse(item.ToString(), out value))
      {
        list.Add(item);
      }
    }
