        public class Call : MarkupExtension
        {
            public string ActionName { get; set; }
            public Call(string actionName) { ActionName = actionName; }
    
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                IProvideValueTarget targetProvider = serviceProvider
                    .GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
                if (targetProvider == null)
                    throw new InvalidOperationException(@"The CallAction extension 
                    can't retrieved the IProvideValueTarget service.");
    
                var target = targetProvider.TargetObject as FrameworkElement;
                if (target == null)
                    throw new InvalidOperationException(@"The CallAction extension 
                        can only be used on a FrameworkElement.");
    
                if (targetProvider.TargetProperty is MethodInfo)
                {
                    var targetEventAddMethod = targetProvider.TargetProperty as MethodInfo;
                    if (targetEventAddMethod != null)
                    {
                        ParameterInfo[] pars = targetEventAddMethod.GetParameters();
                        Type delegateType = pars[1].ParameterType;
                        MethodInfo methodInfo = this.GetType().GetMethod("MyProxyHandler", BindingFlags.NonPublic | BindingFlags.Instance);
                        return Delegate.CreateDelegate(delegateType, this, methodInfo); ;
                    }
    
                }
                else if (targetProvider.TargetProperty is EventInfo)
                {
                    var targetEventInfo = targetProvider.TargetProperty as EventInfo;
                    if (targetEventInfo != null)
                    {
                        Type delegateType = targetEventInfo.EventHandlerType;
                        MethodInfo methodInfo = this.GetType().GetMethod("MyProxyHandler", BindingFlags.NonPublic | BindingFlags.Instance);
                        return Delegate.CreateDelegate(delegateType, this, methodInfo);
                    }
                }
                return null;
            }
    
            void MyProxyHandler(object sender, EventArgs e)
            {
                FrameworkElement target = sender as FrameworkElement;
                if (target == null) return;
                var dataContext = target.DataContext;
                if (dataContext == null) return;
    
                //get the method on the datacontext from its name
                MethodInfo methodInfo = dataContext.GetType()
                    .GetMethod(ActionName, BindingFlags.Public | BindingFlags.Instance);
                methodInfo.Invoke(dataContext, null);
            }
        }
