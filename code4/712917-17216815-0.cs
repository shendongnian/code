    public static class Bootstrapper {
        public static void Init() {
          ServiceLocator.IoC.RegisterSingleton<ILog4NetUsingInterface, Log4NetUsingClass>();
        }
    }
