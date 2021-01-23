    interface IAnimatable
    {
        void Animate();
    }
    class IntegerItem : IAnimatable
    {
        int _n;
        public IntegerItem(int n)
        {
            _n = n;
        }
        public void Animate()
        {
            Console.WriteLine(_n);
        }
    }
    class AnimationSequencer
    {
        public void Update(IAnimatable item)
        {
            item.Animate();
        }
    }
