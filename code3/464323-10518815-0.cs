    public delegate bool MethodInvokerWithBooleanResult();
    Invoke(new MethodInvokerWithBooleanResult(
                 delegate
                 {
                                // do something and return a bool
                                return true;
                 }
             ));
