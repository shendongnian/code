        private static readonly Timer Timer = new Timer(100); 
        public static int CurrentValue;
        private const string Charaters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz1234567890";
        static void Main()
        {
            Timer.Elapsed += delegate
                                  {
                                      if (CurrentValue < Charaters.Length)
                                      {
                                          Console.Write(string.Format("{0}{1}", Charaters[CurrentValue], Environment.NewLine));
                                          CurrentValue++;
                                      }
                                      else
                                      {
                                          Timer.Stop();
                                      }
                                  };
            Timer.Enabled = true;
            Console.ReadLine();
        }
