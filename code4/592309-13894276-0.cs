    static class Utilities {
        public static void CreateBorder( this Texture2D texture,  int borderWidth, Color borderColor ) {
            Color[] colors = new Color[ texture.Width * texture.Height ];
    
            for ( int x = 0; x < texture.Height; x++ ) {
                for ( int y = 0; y < texture.Width; y++ ) {
                    bool colored = false;
                    for ( int i = 0; i <= borderWidth; i++ ) {
                        if ( x == i || y == i || x == texture.Width - 1 - i || y == texture.Height - 1 - i ) {
                            colors[ x * texture.Width + y ] = borderColor;
                            colored = true;
                            break;
                        }
                    }
    
                    if(colored == false)
                        colors[ x * texture.Height + y ] = Color.Transparent;
                }
            }
    
            texture.SetData( colors );
        }
    }
