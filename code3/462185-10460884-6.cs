     private void Animationsss(Grid grd)
            {
                //create an animation
                DoubleAnimation da = new DoubleAnimation();
                //set from animation to start position 
                //dont forget set canvas.left for grid if u dont u will get error
                da.From = Canvas.GetLeft(grd);
                //set second position of grid
                da.To = -100;
                //set duration
                da.Duration = new Duration(TimeSpan.FromSeconds(2));
                //run animation if u want stop ,start etc use story board
                grd.BeginAnimation(Canvas.LeftProperty, da);
    
            }
