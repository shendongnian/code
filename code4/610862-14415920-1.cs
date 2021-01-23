    public class SomeClass
    {
        public string F {get; set;}
        public string T {get; set;}
    }
    
    var data = from lines in File.ReadAllLines(TrainingDataFile)
                                    .Skip(ContainsHeader ? 1 : 0)
                   let f = lines.Split(new[] { FieldSeparator }).ToList<String>()
                   let target = f[TargetVariablePositionZeroBased]
                   select new SomeClass { F=f, T=target };
