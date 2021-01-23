    public class Listener
    {
      public void Subscribe(Metronome m)
      {
        m.Tick += new Metronome.TickHandler(HeardIt);
      }
      private void RaisTick(object sender, EventArgs e)
      {
          m.Tick(sender,e);
      }
      private void HeardIt(Metronome m, EventArgs e)
      {
         System.Console.WriteLine("HEARD IT");
      }
   }
