    // For each row in a board (start with 0, go until 7, increase by 1)
    for (int i = 0; i < 8; i++)
    {
        // start coloring the row. Determine which field within the row needs
        // to be black. In first row, first field is black, in second second
        // field is black, in third row first field is black again and so on.
        // So, even rows have black field in first blace, odd rows have black
        // on second place.
        // We calculate this by determining division remained when dividing by 2.
        int firstBlack = i % 2;
        // Starting with calculated field, and until last field color fields black.
        // Skip every second field. (start with firstBlack, go until 7, increase by 2)
        for (int j = firstBlack; j < 8; j += 2)
        {
            // Color the field black (set to 2)
            board[i][j] = 2;
        }
    }
