     int counter == 0;
         .....
        
         //start process, assume this code will be called several times
         counter++;
         var process = new Process ();
         process.StartInfo = new ProcessStartInfo(file);
                       
         //Here are 2 lines that you need
         process.EnableRaisingEvents = true;
         //Just used LINQ for short, usually would use method as event handler
         process.Exited += (s, a) => 
        { 
          counter--;
          if (counter == 0)//All processed has exited
             {
             ShowWindow(Game1.Handle, SW_RESTORE);
            SetForegroundWindow(Game1.Handle);
             }
        }
        process.Start();
