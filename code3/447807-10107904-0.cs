    interface IFloatPropertySource
    {
        float FloatProperty { get; set; }
    }
    interface ITweenFunction
    {
        float Tween(float start, float end, float t);
    }
    class TweenProcess : GameProcess 
    {
        float m_start;
        IFloatPropertySource m_floatSource;
        ITweenFunction m_tweenFunction;
    
        public TweenProcess(IFloatPropertySource floatSource, ITweenFunction tweenFunction)
        {
            m_floatSource = floatSource;
            m_tweenFunction = tweenFunction;
        }
    
        public override void Update(float elapsed) {
            if (FirstUpdate) {
                m_start = m_floatSource.FloatProperty;
                FirstUpdate = false;
            }
    
            Time += elapsed;
            if (Time >= Duration)
                Finished = true;
    
            m_floatSource.FloatProperty = m_tweenFunction.Tween(start, end, Time / Duration);
        }
    }
