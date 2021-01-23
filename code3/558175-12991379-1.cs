    public class Player
    {
        public void Update()
        {
            //stuff to find nextTile position
            //Call static function toward a class that contains the map data.
            if (Map.TileIsWalkable(nextTile))
                Move();
        }
    }
    public class Map
    {
        public static Map loadedMap; // Handling it as singleton, normally you only load one map at a time.
    
        public static bool TileIsWalkable(Vector2 position)
        {
            if (loadedMap == null) // Throw assert, shouldn't happen.
            return //whatever test need in loadedMap structure
        }
    }
