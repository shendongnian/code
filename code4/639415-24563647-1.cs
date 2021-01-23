    const string data = @"%T\tperson
    %F\tid\tname\taddress\tcity
    %R\t1\tBob\t999 Main St\tBurbank
    %R\t2\tSara\t829 South st\tPasadena
    %T\thouses
    %F\tid\tpersonid\thousetype\tColor
    %R\t25\t1\tHouse\tRed
    %R\t26\t2\tcondo\tGreen";
    var reader = new StringReader(data.Replace("\\t","\t"));
    var rows = Parse(reader);
    foreach (var row in rows)
    {
        foreach (var entry in row)
        {
            Console.Write(entry.Key);
            Console.Write('\t');
            Console.Write('=');
            Console.Write('\t');
            Console.Write(entry.Value);
            Console.WriteLine();
        }
        Console.WriteLine();
    }
