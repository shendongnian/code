    dynamic json  = JsonConvert.DeserializeObject(text);
    foreach (var sentence in json.sentences)
    {
        Console.WriteLine((string)sentence.trans);
    }
    Console.WriteLine();
    foreach (var d in json.dict)
    {
        Console.WriteLine("***TERMS***");
        foreach (var term in d.terms)
        {
            Console.WriteLine((string)term);
        }
        Console.WriteLine("***ENTRY***");
        foreach (var entry in d.entry)
        {
            Console.WriteLine((string)entry.word + " , "  + (double)entry.score);
        }
    }
