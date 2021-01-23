    var summedRows = yourDataGridView
        .Cast<DataGridViewRow>()
        .Where(r => Boolean.Parse(r.Cells[0].Value.ToString()) == true) 
        .GroupBy(r => r.Cells[1].Value)
        .Select(g => new 
                     { 
                         Id = g.Key, 
                         Sum = g.Sum(r => Double.Parse(r.Cells[2].Value.ToString())) 
                     }
        );
