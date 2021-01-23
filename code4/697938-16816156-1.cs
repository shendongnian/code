        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && pastKey.IsKeyUp(Keys.Space))
                Shoot();
            pastKey = Keyboard.GetState();
            spritePosition = spriteVelocity + spritePosition;
            spriteRectangle = new Rectangle((int)spritePosition.X, (int)spritePosition.Y,
                spriteTexture.Width, spriteTexture.Height);
            spriteOrigin = new Vector2(spriteRectangle.Width / 2, spriteRectangle.Height / 2);
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) rotation += 0.025f;
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) rotation -= 0.025f;
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                spriteVelocity.X = (float)Math.Cos(rotation) * tangentialVelocity;
                spriteVelocity.Y = (float)Math.Sin(rotation) * tangentialVelocity;
            }
            else if (Vector2.Zero != spriteVelocity)
            {
                float i = spriteVelocity.X;
                float j = spriteVelocity.Y;
                spriteVelocity.X = i -= friction * i;
                spriteVelocity.Y = j -= friction * j;
                base.Update(gameTime);
            }
            UpdateBullets();
        }
        public void Shoot()
        {
            Bullets newBullet = new Bullets(Content.Load<Texture2D>("ball"));
            newBullet.velocity = new Vector2((float)Math.Sin(rotation), (float)Math.Cos(rotation)) * new Vector2(5f,-5f) + spriteVelocity;
            newBullet.position = spritePosition + newBullet.velocity * 5;
            newBullet.isVisible = true;
            if (bullets.Count < 20)
                bullets.Add(newBullet);
        }
