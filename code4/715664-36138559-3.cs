    public static class ReflectionHelper
    {
        // https://stackoverflow.com/a/13650728/37055
        public static object ReadProperty(
            this object target,
            string propertyName)
        {
            var args = new[] {CSharpArgumentInfo.Create(0, null)};
            var binder = Binder.GetMember(0, propertyName, target.GetType(), args);
            var site = CallSite<Func<CallSite, object, object>>.Create(binder);
            return site.Target(site, target);
        }
        public static string ReadDebuggerDisplay(
            this object target, 
            string propertyName = "DebuggerDisplay")
        {
            string debuggerDisplay = null;
            try
            {
                var value = ReadProperty(target, propertyName) ?? "<null object>";
                debuggerDisplay = value as string ?? value.ToString();
            }
            catch (Exception)
            {
                // ignored
            }
            return debuggerDisplay ?? 
                  $"<ReadDebuggerDisplay failed on {target.GetType()}[{propertyName}]>";
        }
    }
