            Timer t = new Timer();
            t.Interval = 1;
            t.Enabled = true;
            t.Tick += (s, o) =>
                {
                    // interval between 1000ms(1s) & 1H
                    t.Interval =1000*( new Random().Next(3600));
                    //Copy your stuff here
                    File.Copy("from", "to");
   
                };
