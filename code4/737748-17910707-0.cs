    pole = pole.OrderBy(x => x).ToList(); //<<----- this one
    for (int i = 0; i < pole.Count; i++)
    {
          name = pole[i];
          sum_word = 0;
    
          for (int u = 0; u < name.Length; u++)
          {
              sum_word += (name[u] - 'A' + 1);
          }
    
          sum2 += (sum_word*(i + 1));
     }
