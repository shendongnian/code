            var flow = ExecutionContext.SuppressFlow();
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("MyIdentity"), "Role".Split());
            ThreadPool.QueueUserWorkItem((x) => {
                AppDomain.CreateDomain("New domain").DoCallBack(Isolated);
            });
            flow.Undo();
