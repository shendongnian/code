        long sentBytes = 0;      //the sent bytes that updated from sending method
        long prevSentBytes = 0;   //which references to the previous sentByte
        double totalSeconds = 0;   //seconds counter to show total time .. it increases everytime the timer1 ticks.
        private void timer1_Tick(object sender, EventArgs e)
        {
            long speed = sentBytes - prevSentBytes ;  //here's the Transfer-Rate or Speed
            prevSentBytes = sentBytes ;
            labelSpeed.Text = CnvrtUnit(speed) + "/S";   //display the speed like (100 kb/s) to a label
            if (speed > 0)                //considering that the speed would be 0 sometimes.. we avoid dividing on 0 exception
            {
                totalSeconds++;     //increasing total-time
                labelTime.Text = TimeToText(TimeSpan.FromSeconds((sizeAll - sumAll) / speed));
                //displaying time-left in label
                labelTotalTime.Text = TimeToText(TimeSpan.FromSeconds(totalSeconds));
                //displaying total-time in label
            }
        }
        private string TimeToText(TimeSpan t)
        {
            return string.Format("{2:D2}:{1:D2}:{0:D2}", t.Seconds, t.Minutes, t.Hours);
        }
        private string CnvrtUnit(long source)
        {
            const int byteConversion = 1024;
            double bytes = Convert.ToDouble(source);
            if (bytes >= Math.Pow(byteConversion, 3)) //GB Range
            {
                return string.Concat(Math.Round(bytes / Math.Pow(byteConversion, 3), 2), " GB");
            }
            else if (bytes >= Math.Pow(byteConversion, 2)) //MB Range
            {
                return string.Concat(Math.Round(bytes / Math.Pow(byteConversion, 2), 2), " MB");
            }
            else if (bytes >= byteConversion) //KB Range
            {
                return string.Concat(Math.Round(bytes / byteConversion, 2), " KB");
            }
            else //Bytes
            {
                return string.Concat(bytes, " Bytes");
            }
        }
