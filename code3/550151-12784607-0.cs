    while (csv.ReadNextRecord())
        {
            for (int i = 0; i < fieldCount; i++)
                Console.Write(string.Format("{0} = {1};",
                              headers[i],
                              csv[i] ?? "null"));
            Console.WriteLine();
        }
