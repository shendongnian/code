    List<string> name = new List<string>();
    name.Add("              ");
    name.Add("rajesh");
    name.Add("raj");
    name.Add("rakesh");
    name.Add("              ");
    for (int i = 0; i < name.Count(); i++)
    {
      if (string.IsNullOrWhiteSpace(Convert.ToString(name[i])))
      {
        name.RemoveAt(i);
      }
    }
