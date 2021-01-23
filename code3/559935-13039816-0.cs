    private void Main()
    {
         DisplayOptions();
         bool choiceDone;
         
         do
         {
            choiceDone = true;
            switch(GetChoice())
            {
                case ConsoleKey.D1:
                   Console.WriteLine("you chose 1");
                   break;
                case ConsoleKey.D2:
                   Console.WriteLine("you chose 2");
                   break;
                // etc
                default:
                   choiceDone = false;
                   break;
             } while(!choiceDone);
         }
    }
