     this.MouseMove += new MouseEventHandler(MainWindow_MouseMove);
            tm = new System.Timers.Timer();
            tm.Interval = 5000;
            tm.Elapsed += new System.Timers.ElapsedEventHandler(tm_Elapsed);
            tm.Start();
