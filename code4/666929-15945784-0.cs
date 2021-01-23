    using System.Linq;
---
    private void UpdateDiamonds(GameTime gameTime)  
    {  
       for (int i = 0; i &lt; diamonds.Count; ++i)  
        {  
            Gem ruby = diamonds<strong>.ElementAt(i)</strong>;
            ruby.Update(gameTime);
            if (ruby.BoundingCircle.Intersects(Player.BoundingRectangle))
            {
                diamonds.Pop(i--);
                OnGemCollected(ruby, Player);
            }
        }
    }
