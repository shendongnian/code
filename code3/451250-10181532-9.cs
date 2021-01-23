    public void start()
    {
        while(true)
        {
          latch.Wait(); //execution stops
          {
              //execution resumes once the latch counter is zero.
              if (aCheck[0] == "Me")  //double check you have what you need
              {
                  update.Image = Image.fromFile("");
                  latch = new CountdownLatch(1); //reset if you need to do it again
              }
          }
        }
    }
