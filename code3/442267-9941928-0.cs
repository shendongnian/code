    private void UpdateLoop()
    {
        ulong ticks = 0UL;
        _isRunning = true;
        var next = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        while (_isRunning)
        {
            var now = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            int loops = 0;
            while ((now > next) && _isRunning && (loops < MAX_FRAMESKIP))
            {
                ProcessTasks(ticks);
                next += UPDATE_SKIP_TICKS;
                loops++;
                ticks++;
            }
            AccurateSleep(1);
        }
    }
