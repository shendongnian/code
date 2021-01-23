    var f1Lines = File.ReadAllLines(f1Path);
    var f2Lines = File.ReadAllLines(f2Path);
    var diffLines = f1Lines
            .Where((line, index) => index>=f2Lines.Length || line != f2Lines[ index ])
            .Select((line, index)=>line).ToList();
