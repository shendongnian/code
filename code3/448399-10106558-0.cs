    private void LongRunningBackgroundThread() {
       // lots of work
       ...
       // Update my form
       InvokeIfRequired(() => {
           ...update form...
       }
    }
    
    private static void InvokeIfRequired(Action a) {
        if (control.InvokeRequired) {
            control.Invoke(a);
        } else {
            a();
        }
    }
