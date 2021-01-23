    public class Example
    {
      private SuperHero hero = new Superman();
    
      void ThreadA()
      {
        while (true)
        {
          Thread.Sleep(1000);
          hero = new CaptainAmerica();
          Thread.Sleep(1000);
          hero = new GreenLantern();
          Thread.Sleep(1000);
          hero = new IronMan();
        }
    
      void ThreadB()
      {
        while (true)
        {
          hero.FightTheBadGuys();
        }
      }
    }
