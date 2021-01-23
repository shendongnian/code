        int value = 10;
        // Indent column headers
        Console.Write("{0, 4}", null);
        // Write column headers
        for (int x = 1; x <= value; ++x)
            Console.Write("{0, 4}", x);
        // Write column header seperator
        Console.WriteLine();
        Console.WriteLine("_____________________________________________");
        // Write the table
        for (int row = 1; row <= value; ++row)
        {
            // Write the row header
            Console.Write("{0, 4}", row);
            for (int column = 1; column <= value; ++column)
            {
                // Write the row values
                Console.Write("{0, 4}", row * column);
            }
            // Finish the line
            Console.WriteLine();
        }
