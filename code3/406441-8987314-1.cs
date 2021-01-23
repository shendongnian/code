        public static class Debugging
        {
    #if DEBUG
          public static bool ShowFPS = true;
          public static bool PlaySound = true;
    #else
          public static bool ShowFPS = false;
          public static bool PlaySound = false;
    #endif
        }
