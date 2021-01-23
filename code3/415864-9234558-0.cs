    void CheckGrid(bool[,,] grid, int number)
    {
        for (int x = 0; x <= gridXmax - 1; x++)
        {
            for (int y = 0; y <= gridYmax - 1; y++)
            {
                if(grid[number, x,y]) //this will check against grid1 or grid2, depending on int number
                    //logic depends on whether it's grid1 or grid2
            }
        }
    }  
    
        
