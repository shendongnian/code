        //Create the timer object
        System.Windows.Forms.Timer ExampleTimer = new System.Windows.Forms.Timer();
        //Make sure the tag value has a value
        ExampleTimer.Tag = (uint)0;
        //Assign the tick event handler
        ExampleTimer.Tick += ExampleTimer_Tick;
        /// The tick event handler will increment the counter of the timer and stop it when it reaches a value higher then 4
        void ExampleTimer_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer thisTimer = sender as System.Windows.Forms.Timer;
            thisTimer.Tag = (uint)thisTimer.Tag + 1;
            if ((uint)thisTimer.Tag > 4) thisTimer.Stop();
        } 
