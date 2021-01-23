    public virtual void Draw()
    {
        for (int j = 0; j < height; j++)
        {
            Console.SetCursorPosition(p.X, p.Y + j);
            Console.BackgroundColor = backColor;
            for (int i = 0; i <= width; i++)
                Console.Write(' ');
        }
    }
