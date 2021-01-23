    protected override void Update()
            {
                KeyboardState keyboardState = Keyboard.GetState();
                Rectangle oldBounds = player.Bounds;
                if (keyboardState.IsKeyDown(Keys.W)) { player.Y--; }
                if (keyboardState.IsKeyDown(Keys.A)) { player.X--; }
                if (keyboardState.IsKeyDown(Keys.X)) { player.Y++; }
                if (keyboardState.IsKeyDown(Keys.D)) { player.X++; }
                foreach (Platform platform in platforms)
                {
                    if (player.Bounds.Intersects(platform.Bounds))
                    {
                        player.Bounds = oldBounds;
                        break;
                    }
                }
            }
