    backgroundWorker()
    {
        while(isRunning)
        {
            update()
            draw()
        }
     }
     update()
     {
         for each all particles
         {
             update gravity and/or relativity to other particles
         }
     }
     draw()
     {
         clear bitmap
         for each all particles
         {
             draw your particle
         }
         set it to your container
     }
