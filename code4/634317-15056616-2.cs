        public void handleCollisions()
        {
           
            Rect player = new Rect();
            player.X = Canvas.GetLeft(Player);
            player.Y = Canvas.GetTop(Player);
            player.Height = Player.Height;
            player.Width = Player.Width;
           
            foreach (Image item in collisionEnabled)
            {
                if (item.Visibility == Visibility.Visible)
                {
                    Rect obj = new Rect();
                    obj.X = Canvas.GetLeft(item);
                    obj.Y = Canvas.GetTop(item) + canvasShift;
                    obj.Height = item.Height;
                    obj.Width = item.Width;
                    obj.Intersect(player);
                    if (!obj.IsEmpty)
                    {
                        collisionsToHandle.Add(item);
                    }
                }
            }
            foreach (Image item in collisionsToHandle)
            {                
                item.Visibility = Visibility.Collapsed;
    
                if (item.Name.ToLower().Contains("star"))
                {
                    score += 100;
                }
            }
            collisionsToHandle.Clear();
            collisionEnabled.Clear();}
