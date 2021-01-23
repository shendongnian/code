    DateTime maxWaitTimeout = DateTime.Now.AddSeconds(5);
    while (DateTime.Now < maxWaitTimeout)
    {
        System.Windows.Forms.Application.DoEvents();
        System.Threading.Thread.Sleep(100);
        /// now check required element and call 'break' if needed
    }
