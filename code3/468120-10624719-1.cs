    private void button1_Click(object sender, EventArgs e)
    {
        // Here we are on the UI thread, so SynchronizationContext.Current
        // is going to be a WindowsFormsSynchronizationContext that Invokes properly
        ctx = SynchronizationContext.Current;
        ThreadPool.QueueUserWorkItem(
            // This delegate is going to be invoked on a background thread
            s => {
                // This uses the context captured above to invoke
                // back to the UI without the "messy" referencing 
                // of a particular form
                ctx.Send(s2 =>
                {
                   // Interact with your UI here- you are on the UI thread
                },null);
            }
        );
    }
