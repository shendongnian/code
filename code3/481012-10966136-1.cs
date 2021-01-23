    class Clone
    {
        public abstract float Mass { get; }
    }
    class HeavyClone : Clone
    {
        public override float Mass { get { return 12345.6; } }
    }
    class LightClone : Clone
    {
        public override float Mass { get { return 1.23456; } }
    }
