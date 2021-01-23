        public static bool On = true;
...
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            if (!CacheAttribute.On)
            {
                args.ReturnValue = args.Invoke(args.Arguments);
            }
