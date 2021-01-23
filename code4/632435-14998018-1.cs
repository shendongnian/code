    public void ResponseFinished() {
        InvokeSafe(() => X()); //Instead of just X();
    }
    public void InvokeSafe(MethodInvoker m) {
        if (InvokeRequired) {
            BeginInvoke(m);
        } else {
            m.Invoke();
        }
    }
