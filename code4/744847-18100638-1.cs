        public struct CustomTimerStruct
        {
                public uint Counter;
                public DateTime StartDateTime;
                public uint MaximumSecondsToLive;
                public uint MaximumTicksToLive;
        }
        System.Windows.Forms.Timer ExampleTimer = new System.Windows.Forms.Timer();
        ExampleTimer.Tag = new CustomTimerStruct
		{
			Counter = 0,
			StartDateTime = DateTime.Now,
			MaximumSecondsToLive = 10,
			MaximumTicksToLive = 4
		};
        //Note the order of assigning the handlers. As this is the order they are executed.
        ExampleTimer.Tick += Generic_Tick;
        ExampleTimer.Tick += Work_Tick;
        ExampleTimer.Interval = 1;
        ExampleTimer.Start();
        void Generic_Tick(object sender, EventArgs e)
        {
                System.Windows.Forms.Timer thisTimer = sender as System.Windows.Forms.Timer;
                CustomTimerStruct TimerInfo = (CustomTimerStruct)thisTimer.Tag;
                TimerInfo.Counter++;
                //Stop the timer based on its number of ticks
                if (TimerInfo.Counter > TimerInfo.MaximumTicksToLive) thisTimer.Stop();
                //Stops the timer based on the time its alive
                if (DateTime.Now.Subtract(TimerInfo.StartDateTime).TotalSeconds > TimerInfo.MaximumSecondsToLive) thisTimer.Stop();
        }
        void Work_Tick(object sender, EventArgs e)
        {
            //Do work specifically for this timer
        }
