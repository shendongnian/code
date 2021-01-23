    i = 0;
    foreach (List<string> tr in res) {
        for (int k = 0; k < tr.Count; k++) {
            string td = tr.[k];
            Console.Write("[{0}] ", td);
            tr[k] = cleanStrings(td); // line with no error anymore
        }
        i += tr.Count;
        Console.WriteLine();
    }
    Console.WriteLine("Total number of items: {0}", i);
