        // Site Collection Storage Used (GB)
        sum = (int)doc.DocumentNode.SelectSingleNode("//table")
            // The sum will be of the row elements
            .Elements("tr")
            // Skip this many rows from the top
            .Skip(1)
            // .ElementAt(2) = third column
            // .Last() = last column
            .Sum(tr => int.Parse(tr.Elements("td").ElementAt(3).InnerText)); 
        Console.WriteLine("Site Collection Storage Used (GB): " + sum);
