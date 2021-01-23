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
