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
        float start;
        IFloatPropertySource floatSource;
        ITweenFunction tweenFunction;
    
        public TweenProcess(IFloatPropertySource floatSource, ITweenFunction tweenFunction)
        {
            this.floatSource = floatSource;
            this.tweenFunction = tweenFunction;
        }
    
        public override void Update(float elapsed) {
            if (FirstUpdate) {
                start = floatSource.FloatProperty;
                FirstUpdate = false;
            }
    
            Time += elapsed;
            if (Time >= Duration)
                Finished = true;
    
            floatSource.FloatProperty = tweenFunction.Tween(start, end, Time / Duration);
        }
    }
