            var copy = ExecutionContext.Capture();
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("MyIdentity"), "Role".Split());
            ExecutionContext.Run(copy, new ContextCallback((x) => {
                AppDomain.CreateDomain("New domain").DoCallBack(Isolated);
            }), null);
