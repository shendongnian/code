     private void Animation(Grid grd)
            {
                ThicknessAnimation ta = new ThicknessAnimation();
                //your first place
                ta.From = grd.Margin;
                //this move your grid 1000 over from right side
                ta.To = new Thickness(0, 0, 1000, 0);
                //time the animation playes
                ta.Duration = new Duration(TimeSpan.FromSeconds(10));
                //dont need to use story board but if you want pause,stop etc use story board
                grd.BeginAnimation(Grid.MarginProperty, ta);
            }
