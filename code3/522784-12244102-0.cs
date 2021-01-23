    internal void HandleDraw(GameTime gameTime)
    {
        Draw(gameTime);
        if (Children.Count > 0)
        {
            // draw children
            foreach (Control child in Children.Values.OfType<Control>())
            {
                if (child.Visible)
                {
                    Engine.CurrentTransformation.Push(Matrix.Multiply(
                        child.Transformation,
                        Engine.CurrentTransformation.Peek()
                    ));
                    child.HandleDraw(gameTime);
                    Engine.CurrentTransformation.Pop();
                }
            }
        }
    }
