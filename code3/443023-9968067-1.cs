    public class Icon
    {
       private string mTextureName;
       private Texture2D mTexture;
       public Icon(string pTextureName)
       {
          mTextureName = pTextureName;
       }
       ...
       public void LoadContent(ContentManager Content)
       {
          mTexture = Content.Load<Texture2D>(mTextureName);
       }
       ...
    }
    public class MenuButton : SpriteObject
    {
       private Icon spriteIcon;
       //Different Icons, static for loading
       private static Icon playButtonIcon = new Icon("Menu Items/Menu Buttons/PlayButtonIcon");
       ...
       public MenuButton(int requestedX, int requestedY, int requestedWidth, int requestedHeight, MenuButtonType requestedMenuButtonType)
          : base(requestedX, requestedY, requestedWidth, requestedHeight)
       {
          ...
          spriteIcon = playButtonIcon;
          ...
       }
       public void LoadContent(ContentManager Content)
       {
          ...
          playButtonIcon.LoadContent(Content);
          ...
       }        
    }
