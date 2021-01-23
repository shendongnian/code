    public class Mover
    {
        private List<IMoveable> _moveables = new List<IMoveable>();
        public void AddAsTarget(IMoveable moveable)
        {
            _moveables.Add(moveable); // Null checks, and such, yada...
        }
        public void Reposition(int dx, int dy)
        {
            foreach(var moveable in _moveables)
            {
                moveable.MoveBy(dx, dy);
            }
        }
    }
