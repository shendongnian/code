            // INTRODUCE CONDITIONS HERE TO DETERMINE +/- COMBINATION.
            cells.Add(
                new Cell()
                {
                    X = c1.X < c2.X? c1.X - triangleAltitude : c1.X + triangleAltitude,
                    Y = c1.Y < c2.Y ? c1.Y - deltaHalf : c1.Y + deltaHalf
                }
            );
            cells.Add(
                new Cell()
                {
                    X = c2.X < c1.X ? c2.X - triangleAltitude : c2.X + triangleAltitude,
                    Y = c2.Y < c1.Y ? c2.Y - deltaHalf : c2.Y + deltaHalf
                }
            );
