    public class NpcTest : NpcBase
    {
        public NpcTest()
        {
            _position = 0;
            _target = 0;
        }
        // Async operation to count
        public Task MoveTo(int newPosition)
        {
            // Store new target
            _target = newPosition;
            return BeginTask();
        }
        public int Position
        {
            get
            {
                return _position;
            }
        }
        public void onFrame()
        {
            if (_position == _target)
            {
                EndTask();
            }
            else if (_position < _target)
            {
                _position++;
            }
            else
            {
                _position--;
            }
        }
        private int _position;
        private int _target;
    }
