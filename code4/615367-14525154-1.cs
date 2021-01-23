    class Room
    {
      ... // private fields about room
      ...
      List<Block> blocks;
    
    Pubic void Draw(GameTime gt, SpriteBatch sb)
      {
         sb.Draw(private room fields here);
         foreach(Block b in blocks)
             b.Draw(gt, sb)
      }
    }
