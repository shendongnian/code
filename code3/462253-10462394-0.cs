    public static void DrawStringWithStyle(this SpriteBatch batch, SpriteFont font, Vector2 pos, string text, Color color )
    {
       Color CurrentColor = color;
       string[] paragraphs = Regex.Split( text, @"\\c([a-fA-F0-9]{6})" );
         
       for ( int i=0; i< paragraphs.Length; i++)
       {
          batch.DrawString( font, paragraphs[i], pos, CurrentColor );
          if ( i+1<paragraphs.Length )
          {
              pos.X += font.MeasureString( paragraphs[i] ).X;
              i++;
              CurrentColor.R = byte.Parse( paragraphs[i].Substring( 0, 2 ) );
              CurrentColor.G = byte.Parse( paragraphs[i].Substring( 2, 2 ) );
              CurrentColor.B = byte.Parse( paragraphs[i].Substring( 4, 2 ) );
          } 
       }               
    }
