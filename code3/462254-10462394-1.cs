    public static void DrawStringWithStyle( this SpriteBatch batch, SpriteFont font, Vector2 pos, string text, Color color, SpriteFont BoldFont=null )
    {
        string[] paragraphs = Regex.Split( text, @"\\(c[a-fA-F0-9]{6})|\\(b)|\\(n)" );
        Color CurrentColor = color;
        SpriteFont CurrentFont = font;
                    
        for ( int i=0; i< paragraphs.Length; i++ )
        {
            batch.DrawString( CurrentFont, paragraphs[i], pos, CurrentColor );
    
            if ( i+1<paragraphs.Length )
            {
                pos.X += CurrentFont.MeasureString( paragraphs[i] ).X;
                i++;
    
                switch (char.ToLower(paragraphs[i][0]))
                {
                    case 'c':
                        CurrentColor.R = byte.Parse( paragraphs[i].Substring( 1, 2 ) );
                        CurrentColor.G = byte.Parse( paragraphs[i].Substring( 3, 2 ) );
                        CurrentColor.B = byte.Parse( paragraphs[i].Substring( 5, 2 ) );
                        break;
                    case 'n': CurrentFont = font; break;
                    case 'b': CurrentFont = BoldFont; break;
                }
            }
        }
    }
