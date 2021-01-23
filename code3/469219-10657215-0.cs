     public interface IDoThingy
     {
          void DoStuff();
     }
     public class IncreaseVolumeThingy : IDoThingy
     {
         public int Volume { get; set; }
         public IncreaseVolumeThingy(int volume)
         {
             Volume = volume;
         }
         public void DoStuff()
         {
             SomeClass.ChangeMasterVolume(Volume);
         }
     }
     public class Command
     {
          protected IDoThingy _thingy = null;
          public Command(IDoThingy thingy)
          {
               _thingy = thingy;
          }
          public void ExecuteCommand()
          {
              _thingy.DoStuff();
          }
     }
