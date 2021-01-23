    public static void AutoInvoke(
        this System.ComponentModel.ISynchronizeInvoke self,
        Action action)
    {
        if (self == null) throw new ArgumentNullException("self");
        if (action == null) throw new ArgumentNullException("action");
        if (self.InvokeRequired) {
            self.Invoke(action);
        } else {
            action();
        }
    }
