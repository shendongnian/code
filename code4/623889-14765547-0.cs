    List<int> arrays = new List<int>();
    
    string periodohorario = string.Empty;
    
    for (int i = 0; i < CaminoHormiga.Length; i++)
    {
       arrays.Add(CaminoHormiga);
    }
    
    hg.dgHorarioGen.DataSource = arrays;
