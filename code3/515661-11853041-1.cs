            // INTRODUCE CONDITIONS HERE TO DETERMINE +/- COMBINATION.
            cells.Add(
                new Cell()
                {
                    X = c1.X < c2.X? c1.X - delta : c1.X + delta ,
                    Y = c1.Y < c2.Y ? c1.Y - delta : c1.Y + delta
                }
            );
            cells.Add(
                new Cell()
                {
                    X = c2.X < c1.X ? c2.X - delta : c2.X + delta,
                    Y = c2.Y < c1.Y ? c2.Y - delta : c2.Y + delta 
                }
            );
