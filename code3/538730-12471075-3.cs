    var secondDataSet = firstDataSet.GroupBy(entry => entry.Col5).Select
    (
        group => new MyType
        {
            Col1 = "B",
            Col2 = <whatever>,
            Col3 = <whatever>,
            Col4 = group.Sum(entry => entry.Col4),
            Col5 = group.Key
        }
    );
 
