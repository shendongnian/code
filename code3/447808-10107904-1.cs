    class SpriteAlphaSource : IFloatPropertySource
    {
        Sprite m_sprite;
    
        SpriteAlphaSource(Sprite sprite)
        {
            m_sprite = sprite;
        }
    
        public float FloatProperty
        {
            get
            {
                return m_sprite.Alpha;
            }
            set
            {
                m_sprite.Alpha = value;
            }
        }
    }
