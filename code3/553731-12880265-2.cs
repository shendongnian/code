    var timer = new Timer{Interval = 30};
    timer.Tick += (s, ev) =>
                        {
                            Xcoord.Text = Cursor.Position.X.ToString();
                            Ycoord.Text = Cursor.Position.Y.ToString();
                        };
    timer.Start();
