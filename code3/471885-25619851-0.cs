    trait TCircle
    {
        public int Radius { get; set; }
        public int Surface { get { ... } }
    }
    trait TColor { ... }
    class MyCircle
    {
        uses { TCircle; TColor }
    }
