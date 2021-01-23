    class SpriteAlphaSource : IFloatPropertySource
    {
        Sprite sprite;
    
        public SpriteAlphaSource(Sprite sprite)
        {
            this.sprite = sprite;
        }
    
        public float FloatProperty
        {
            get
            {
                return sprite.Alpha;
            }
            set
            {
                sprite.Alpha = value;
            }
        }
    }
