        protected override void LoadContent()
        {
            int x = 0;
            int y = 0;
            Vector2 startPosition;
            for (int i = 0; i < brickLayout.GetLength(0); i++)
            {
                for (int j = 0; j < brickLayout.GetLength(1); j++)
                {
                    startPosition = new Vector2(x, y);
                    brickLayout[i, j] = new Brick(game, 20, 1, startPosition);
                    // This new line...
                    brickLayout[i, j].LoadContent();
                    x += 20;
                }
                y += 20;
            }
            base.LoadContent();
        }
