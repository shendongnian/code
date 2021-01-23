            Pen[] gradient = { new Pen(Color.FromArgb(255, 200, 200, 255)), new Pen(Color.FromArgb(150, 200, 200, 255)), new Pen(Color.FromArgb(100, 200, 200, 255)) };
            int x = 20;
            int y = 20;
            int sizex = 200;
            int sizey = 10;
            int value = 25;
            //draw progress bar basic outline (position - 1 to compensate for the outline)
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x-1, y-1, sizex, sizey));
            //draw the percentage done
            e.Graphics.FillRectangle(Brushes.AliceBlue, new Rectangle(x, y, (sizex/100)*value, sizey));
            //to add the glow effect just add lines around the area you want to glow.
            for (int i = 0; i < gradient.Length; i++)
            {
                e.Graphics.DrawRectangle(gradient[i], new Rectangle(x - (i + 1), y - (i + 1), (sizex / 100) * value + (2 * i), sizey + (2 * i)));
            }
