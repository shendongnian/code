    public class Call : MarkupExtension
    {
        public Call() { }
      
        public string MethodName { get; set; }
        public string Path { get; set; }
        public string ElementName { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            IProvideValueTarget targetProvider = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            if (targetProvider != null)
            {
                var target = targetProvider.TargetObject as FrameworkElement;
                if (target != null)
                {
                    if (targetProvider.TargetProperty is MethodInfo)
                    {
                        var targetEventAddMethod = targetProvider.TargetProperty as MethodInfo;
                        if (targetEventAddMethod != null)
                        {
                            var delegateType = targetEventAddMethod.GetParameters()[1].ParameterType;
                            var methodInfo = this.GetType().GetMethod("MyProxyHandler", BindingFlags.NonPublic | BindingFlags.Instance);
                            return Delegate.CreateDelegate(delegateType, this, methodInfo); ;
                        }
                    }
                    else if (targetProvider.TargetProperty is EventInfo)
                    {
                        var targetEventInfo = targetProvider.TargetProperty as EventInfo;
                        if (targetEventInfo != null)
                        {
                            var delegateType = targetEventInfo.EventHandlerType;
                            MethodInfo methodInfo = this.GetType().GetMethod("MyProxyHandler", BindingFlags.NonPublic | BindingFlags.Instance);
                            return Delegate.CreateDelegate(delegateType, this, methodInfo);
                        }
                    }
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
            MethodInfo methodInfo = dataContext.GetType().GetMethod(MethodName, BindingFlags.Public | BindingFlags.Instance);
            if (!string.IsNullOrEmpty(ElementName))
            {
                var element = FindVisualChildren(dataContext as DependencyObject).FirstOrDefault(c => c.Name.Equals(ElementName));
                if (element != null)
                {
                    var path = element.GetType().GetProperty(Path);
                    if (path != null)
                    {
                        methodInfo.Invoke(dataContext, new object[] { path.GetValue(element, null) });
                    }
                    return;
                }
            }
            if (!string.IsNullOrEmpty(Path))
            {
                var path = dataContext.GetType().GetProperty(Path);
                if (path != null)
                {
                    methodInfo.Invoke(dataContext, new object[] { path.GetValue(dataContext, null) });
                }
                return;
            }
            methodInfo.Invoke(dataContext,null);
        }
