    public class TileList: SpriteList {
    
        public new IEnumerator<Tile> GetEnumerator()
        {
            foreach (var tile in GetBase())
            {
                if (tile is Tile)
                {
                    yield return tile as Tile;
                }
            }
        }
    
        protected SpriteList GetBase()
        {
            return (SpriteList )this;
        }
    }
