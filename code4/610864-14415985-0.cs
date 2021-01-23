    var data = from lines in File.ReadAllLines(TrainingDataFile)
                             .Skip(ContainsHeader ? 1 : 0)
           let f = lines.Split(new[] { FieldSeparator }).ToList<String>()
           let target = f[TargetVariablePositionZeroBased]
           select new { F=f, T=target };
    SomeMethod(data);
    public T SomeMethod<T>(IEnumerable<T> col)
    {
        //choose the return type..
    }
