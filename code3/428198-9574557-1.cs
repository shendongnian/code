        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
    #if DEBUG
            (source as Timer).Stop();
            // or
            (source as Timer).Enabled = false;
    #endif
            // do your work
    #if DEBUG
            (source as Timer).Start();
            // or
            (source as Timer).Enabled = true;
    #endif
        }
