    [Serializable]
        public class LazyLoadGetter : LocationInterceptionAspect, IInstanceScopedAspect
        {
            private object backing;
    
            public override void OnGetValue(LocationInterceptionArgs args)
            {
                if (backing == null)
                {
                    args.ProceedGetValue();
                    backing = args.Value;
                }
    
                args.Value = backing;
            }
    
            public object CreateInstance(AdviceArgs adviceArgs)
            {
                return this.MemberwiseClone();
            }
    
            public void RuntimeInitializeInstance()
            {
                
            }
        }
