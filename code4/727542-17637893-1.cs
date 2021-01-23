    public class CommandFactory
    {
         public static int ALGO_1 = 1;
         public static int ALGO_2 = 2;
         public Command getInstance(int discriminator)
         {
              // Check the value, and if it matches a pre-defined value..
              switch(discriminator)
              {
                  case ALGO_1:
                              return new Command1();
                              break;
                  case ALGO_2:
                              return new Command2();
                              break;
              }
         }
    }
