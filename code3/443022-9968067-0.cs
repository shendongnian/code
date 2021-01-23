    private static MenuButtonType savedMenuButtonType;
    public MenuButton(int requestedX, int requestedY, int requestedWidth, int requestedHeight, MenuButtonType requestedMenuButtonType)
       : base(requestedX, requestedY, requestedWidth, requestedHeight)
       {
          ...
          savedMenuButtonType = requestedMenuButtonType;
          ...
       }
    public static void LoadContent(ContentManager Content)
    {
       ...
       //Main Menu Icons
       ...
       //About Menu Icons
       ...
       spriteTexture = GetRequestedSpriteTexture();
    }
    private static Texture2D GetRequestedSpriteTexture()
    {
       switch (savedMenuButtonType)
       {
          case MenuButtonType.play:
             return playButtonIcon;
             break;
          ...
    }
