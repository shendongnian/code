    public class Ball
    {
        public Ball()
        {
            _apple = new Apple();
        }
        public Apple MyApple
        {
            get { return _apple; }
            set { _apple = value; }
        }
        private Apple _apple;
    }
