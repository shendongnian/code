    public sealed class ColorItem : IEquatable<ColorItem>
    {
        private readonly string text;
        private readonly Color color;
        public string Text { get { return text; } }
        public Color Color { get { return color; } }
        public ColorItem(string text, Color color)
        {
            this.text = text;
            this.color = color;
        }
        public override bool Equals(object other)
        {
            return Equals(other as ColorItem);
        }
        public bool Equals(ColorItem otherItem)
        {
            if (otherItem == null)
            {
                return false;
            }
            return otherItem.Text == text && otherItem.Color == color;
        }
        public override int GetHashCode()
        {
            int hash = 19;
            hash = hash * 31 + (text == null ? 0 : text.GetHashCode());
            hash = hash * 31 + color.GetHashCode();
            return hash;
        }
    }
