    List<AnimationElement> HitElements;
    private Preparationanimation Hit4;
    
     public override void LoadContent()
     {
            HitElements = new List<AnimationElement>();
            Hit4 = new Preparationanimation(SpriteSheetElements1, new Color(255, 255, 255, 128), 1f, false)
     }
    
     if (IntersectPixels(Player1.HitboxAtt, Player1.playerTextureData, Player2.Hitbox, Player2.playerTextureData))
     {
         foreach (AnimationElement a in HitElements)
         {
           a.PlayAnimation(Hit4, content);
         }
     }
    
     public override void Draw(GameTime gameTime)
     {
         foreach (AnimationElement a in HitElements)
         {
             a.Draw(spriteBatch, gameTime, positionElement, false, true);
         }
          
     }
