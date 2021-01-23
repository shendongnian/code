            TableRow gamerow = new TableRow();
    
            if (currentdatetime != LastDateTime)
            {
                
                TableCell timecell = new TableCell();
                timecell.Controls.Add(new LiteralControl(ntime));
                gamerow.Cells.Add(timecell);
    
                
            }//check to see if next game is part of the current row  
            else
            {
                TableCell gamecell = new TableCell();
                gamecell.Controls.Add(new LiteralControl(TeamA + ".vs." + TeamB));
                gamerow.Cells.Add(gamecell);
            } 
    
            if (i + 1 != GameCount & ndate != nextdate)
             {
                    ScheduleTable.Rows.Add(gamerow);
             }
