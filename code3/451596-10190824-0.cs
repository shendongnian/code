        TableRow gamerow = new TableRow();
        TableCell timecell = new TableCell();
        TableCell gamecell = new TableCell();
        TableRow daterow = new TableRow();
        TableCell datecell = new TableCell();
        for (int i = 0; i < GameCount; i++)
        {
            DateTime currentdatetime = (DateTime)Schedules.Tables["Schedule"].Rows[i]["datetime"];
            string ndate = currentdatetime.ToString("MM/dd/yyy");
            string ntime = currentdatetime.ToString("HH:mm");
            string nextdate = currentdatetime.ToString("MM/dd/yyy");
            if (i + 1 != GameCount)
            {
                DateTime nextdatetime = (DateTime)Schedules.Tables["Schedule"].Rows[i + 1]["datetime"];
                nextdate = nextdatetime.ToString("MM/dd/yyy");
            }
            string TeamA = Schedules.Tables["Schedule"].Rows[i]["teamA"].ToString();
            string TeamB = Schedules.Tables["Schedule"].Rows[i]["teamB"].ToString();
            //check to see if date is current 
            if (LastDate != ndate)
            {
                 daterow = new TableRow();
                 datecell = new TableCell();
                datecell.ColumnSpan = 7;
                datecell.Controls.Add(new LiteralControl(ndate));
                daterow.Cells.Add(datecell);
                ScheduleTable.Rows.Add(daterow);
                LastDate = ndate;
            }
            //print the games 
            if (currentdatetime != LastDateTime)
            {
                 gamerow = new TableRow();
                 timecell = new TableCell();
                timecell.Controls.Add(new LiteralControl(ntime));
                gamerow.Cells.Add(timecell);
                if (i + 1 != GameCount & ndate != nextdate)
                {
                    ScheduleTable.Rows.Add(gamerow);
                }
            }//check to see if next game is part of the current row  
            else
            {
                 gamecell = new TableCell();
                gamecell.Controls.Add(new LiteralControl(TeamA + ".vs." + TeamB));
                gamerow.Cells.Add(gamecell);
            }
