      string s = "Subba Cargos";
      string s2 = "Cargos Subba";
    
      var isSame=  s.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).
                   OrderBy(o => o).SequenceEqual(s2.Split(new[] {' '}, 
                       StringSplitOptions.RemoveEmptyEntries).
                   OrderBy(o => o));
