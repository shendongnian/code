    button = new Button(Content.Load<Texture2D>("Textures\\Button"), new Vector2(100, 100));
    button.OnClick += new ButtonEvent(button_OnClick);
    button.OnMouseEnter += new ButtonEvent(button_OnMouseEnter);
    button.OnMouseLeave += new ButtonEvent(button_OnMouseLeave);
    button.OnHover += new ButtonEvent(button_OnHover);
