    class Form1 : Form
    {
      Timer _Timer;
      int _Index = 0;
      public Form1()
      {
        _Timer = new Timer { Enabled = true, Interval = 20000 };
        _Timer.Tick += ( s, e ) => TimerTick();
      }
      void TimerTick()
      {
         if ( _Index >= 100000 )
         {
           _Timer.Dispose();
           _Timer = null;
           return;
         }
         webBrowser.Navigate( ... );
         _Index++;
       }
 
