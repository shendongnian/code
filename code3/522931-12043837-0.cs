    [Test]
    public void X()
    {
        var tiles = genworld();
        for(int i = 0; i < tiles.Length; i++)
        {
            for(int j = 0; j < tiles[i].Length; j++)
            {
                Console.Write(tiles[i][j]);
            }
            Console.WriteLine();
        }
    }
    private int[][] genworld(int size = 25)
    {
        /* the solution with the database "worked" because it was slow. 
           going in memory will cause this to run faster so you need to
           declare a Random first and use it later.  this approach avoids
           a class-level variable.
        */
        var r = new Random();
        Func<int, int, int> gentile = (grass, desert) =>
                                            {
                                                var number = r.Next(1, grass + desert);
                                                return number < desert ? 1 : 0;
                                            };
            
        var tiles = new int[size][];
        for (int i = 0; i < size; i++)
        {
            tiles[i] = new int[size];
        }
        for (var row = 0; row < size; row++)
        {
            for (var col = 0; col < size; col++ )
            {
                int tileabove = 9999;
                int tilenextto = 9999;
                int tile = 9999;
                if (row >= 1)
                {
                    tileabove = tiles[row - 1][col];
                }
                if (col >= 1)
                {
                    tilenextto = tiles[row][col - 1];
                }
                if (tile == 9999 && (tileabove == 9999 || tilenextto == 9999))
                {
                    tile = gentile(10, 10);
                }
                if (tile == 9999 && tileabove == 0 && tilenextto == 0)
                {
                    tile = gentile(200, 10);
                }
                if (tile == 9999 && tileabove == 1 && tilenextto == 1)
                {
                    tile = gentile(10, 200);
                }
                if (tile == 9999 && tileabove == 1)
                {
                    tile = gentile(10, 10000);
                }
                if (tile == 9999 && (tileabove == 1 || tilenextto == 1))
                {
                    tile = gentile(20, 80);
                }
                tiles[row][col] = tile;
            }
        }
        return tiles;
    }
