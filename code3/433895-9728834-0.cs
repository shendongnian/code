    int c = ran.Next(1, 5);
    
    for (int i = 0; i < box_width; i += 2)
    {
        for (int j = 0; j < box_height; j += 2)
        {
            Color cellColor;
    
            switch (c)
            {
                case 1:
                    cellColor = Color.Yellow;
                    break;
                case 2:
                    cellColor = Color.LightGray;
                    break;
                case 3:
                    cellColor = Color.LightBlue;
                    break;
                case 4:
                    cellColor = Color.Blue;
                    break;
            }
    
            MyClass.grid.Rows[j].Cells[i].Style.BackColor = cellColor;
            MyClass.grid.Rows[j].Cells[i+1].Style.BackColor = cellColor;
            MyClass.grid.Rows[j+1].Cells[i].Style.BackColor = cellColor;
            MyClass.grid.Rows[j+1].Cells[i+1].Style.BackColor = cellColor;
        }
    }
