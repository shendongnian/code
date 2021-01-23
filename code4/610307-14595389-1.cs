    public override void OnEntry(MethodExecutionArgs args)
    {
         this.logger = LogManager.GetCurrentClassLogger();
         logger.Debug(string.Format("Entering {0}.{1}.", args.Method.DeclaringType.Name, args.Method.Name));
    }
