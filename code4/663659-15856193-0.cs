    List<string> lstGuid1 = new List<string>;
    List<string> lstGuid2 = new List<string>;
    lstGuid1.AddRange(guid1.ToString().Split("-"));
    lstGuid2.AddRange(guid2.ToString().Split("-"));
    string guid3 = null;
    if(lstGuid1.Length == lstGuid2.Length)
    {
      for(int i = 0; i < lstGuid1.Length; i++)
      {
        guid3 += lstGuid1[i] + "-" + lstGuid2[i] + "-";
      }
      guid3 = guid3.Substring(0, guid3.Length - 1);
    }
