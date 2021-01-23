    public override bool Equals(object obj)
    {
        if (obj is Color)
        {
            Color color = (Color) obj;
            if ((this.value == color.value)
                && (this.state == color.state)
                && (this.knownColor == color.knownColor))
            {
                return ((this.name == color.name)
                    || ((this.name != null)
                       && (color.name != null)
                       && this.name.Equals(color.name)));
            }
        }
        return false;
    }
