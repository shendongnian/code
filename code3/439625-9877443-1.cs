            //Init the holder
            _holder = new Rectangle(0, 0, TileWidth, TileHeight);
            //Figure out the min and max tile indices to draw
            var minX = Math.Max((int)Math.Floor((float)worldArea.Left / TileWidth), 0);
            var maxX = Math.Min((int)Math.Ceiling((float)worldArea.Right / TileWidth), Width);
            var minY = Math.Max((int)Math.Floor((float)worldArea.Top / TileHeight), 0);
            var maxY = Math.Min((int)Math.Ceiling((float)worldArea.Bottom / TileHeight), Height);
            for (var y = minY; y < maxY; y++) {
                for (var x = minX; x < maxX; x++) {
                        
                    _holder.X = x * TileWidth;
                    _holder.Y = y * TileHeight;
                    var t = tileLayer[y * Width + x];
                    spriteBatch.Draw(
                        t.Texture,
                         _holder, 
                        t.SourceRectangle,
                        Color.White, 
                        0,
                        Vector2.Zero,
                        t.SpriteEffects, 
                        0);
                }
            }
