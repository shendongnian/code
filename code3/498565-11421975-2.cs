    IEnumerable<List<T>> Partition<T>(IEnumerable<T> col, int partitionSize) {
     if (col.Count() == 0) {
      return new List<List<T>>();
     } else {
      var l = new List<List<T>>();
      l.Add(col.Take(partitionSize).ToList());
      return l.Concat(Partition(col.Skip(partitionSize), partitionSize));
     }
    }
    class TheClass {
     public int A, B, C;
    }
    return Partition(sheet.Cells["A2:C2"], 3)
             .Select(cells => new TheClass { 
               A = int.Parse(cells[0].Value),
               B = int.Parse(cells[1].Value),
               C = int.Parse(cells[2].Value)
             });
