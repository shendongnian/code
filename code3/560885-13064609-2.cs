     public interface IEngine1 {
     }
     public interface IEngine1Config {
         int Param1 {get;}
     }
     public Engine1 : IEngine1 {
         IEngine1Config _config;
         public Engine1(IEngine1Config config) {
            _config = config;
         }
     }
