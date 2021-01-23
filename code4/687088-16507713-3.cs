public class TheSystem
{
   public SystemMode Mode;
   public void Save()
   {
      Mode.Save();
   }
   public SystemDocument Read()
   {
      return Mode.Read();
   }
}
public abstract class SystemMode
{
   public static SystemMode ReadOnly = new ReadOnlyMode();
   public static SystemMode ReadWrite = new ReadWriteMode();
   internal abstract void Save();
   internal abstract SystemDocument Read();
   private class ReadOnlyMode : SystemMode
   {
      internal override void Save() {...}
      internal override SystemDocument Read() {...}
   }
   private class ReadWriteMode : SystemMode
   {
      internal override void Save() {...}
      internal override SystemDocument Read() {...}
   }
}
TheSystem.Mode = SystemMode.ReadOnly;
