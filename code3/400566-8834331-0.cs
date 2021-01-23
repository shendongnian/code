    var lines = System.IO.File.ReadAllLines(@"C:\Temp\FileName.txt");
    var result = new Dictionary<string, Int32>();
    foreach(var line in lines){
        if(result.ContainsKey(line))
            result[line]++;
        else{
            result.Add(line, 1);
        }
    }
