     [Flags]
     public enum Alignment { Center=0, Left=1, Right=2, Top=4, Bottom = 8 }
     public void DrawString(SpriteFont font, string text, Rectangle bounds, Alignment align, Color color )
        {
            Vector2 size = font.MeasureString( text );
            Vector2 pos = bounds.GetCenter( );
            Vector2 origin = size*0.5f;
            if ( align.HasFlag( Alignment.Left ) )
                origin.X += bounds.Width/2 - size.X/2;
           
            if ( align.HasFlag( Alignment.Right ) )
                origin.X -= bounds.Width/2 - size.X/2;
           
            if ( align.HasFlag( Alignment.Top ) )
                origin.Y += bounds.Height/2 - size.Y/2;
           
            if ( align.HasFlag( Alignment.Bottom ) )
                origin.Y -= bounds.Height/2 - size.Y/2;
           
            DrawString( font, text, pos, color, 0, origin, 1, SpriteEffects.None, 0 );
        }
