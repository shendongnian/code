    public class Window
    {
        public string Size { get; set; }
        public string Color { get; set; }
        public bool IsEnergySaving { get; set; }
        public Window() { }
        public Window(string size, string color, bool isEnergySaving)
        {
            Size = size;
            Color = color;
            IsEnergySaving = isEnergySaving;
        }
        public override bool Equals(object obj)
        {
            Window other = obj as Window;
            if (other == null)
                return false;
            return Color == other.Color &&
                   IsEnergySaving == other.IsEnergySaving;
        }
        public override int GetHashCode()
        {
            int hash = 19;            
            hash = hash * 23 + Color.GetHashCode();
            hash = hash * 23 + IsEnergySaving.GetHashCode();
            return hash;
        }
    }
