    private void PointCreated(object sender, IdEventArgs e)
    {
        // Ensure the event was received in the calling thread
        if (this.InvokeRequired)
        {
            if (e != null)
            {
                // We aren't in the correct thread so pass on the event
                this.BeginInvoke(new Controller.ControllerEventHandler(this.PointCreated), new object[] { sender, e });
            }
        }
        else
        {
            lock (this)
            {
                Console.WriteLine("Event Fired!");
                // TODO: Do some stuff here
            }
        }
    }
