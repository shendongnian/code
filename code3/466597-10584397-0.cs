    bool keyDown = false;
    public void Update(GameTime gameTime)
    {
        teclaActual = Keyboard.GetState();
        tiempoTranscurrido = gameTime.ElapsedGameTime.Milliseconds;
        if (tiempoTranscurrido > 50)
        {
            tiempoTranscurrido = 0;
            if (teclaActual.IsKeyDown(Keys.Down) && !keyDown)
            {
                keyDown = true;
                if (cambiar > 2)
                    cambiar = 0;
                else
                    cambiar++;
            }
            if (teclaActual.IsKeyUp(Keys.Down))
            {
                keyDown = false;
            }
        }
    }
