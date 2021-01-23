    using System.IO;
    using System.Runtime.InteropServices;
    public class ForceFailure
    {
      [DllImport("kernel32.dll")]
      public static extern uint GetLastError();
      [DllImport("kernel32.dll", SetLastError = true)]
      private static extern bool SetVolumeLabel(string lpRootPathName, string lpVolumeName);
      public static void Main()
      {
        if (SetVolumeLabel("XYZ:\\", "My Imaginary Drive "))
          System.Console.WriteLine("It worked???");
        else
        {
          System.Console.WriteLine(Marshal.GetLastWin32Error());
          try
          {
            using (new FileStream("sdsdafsdfsdfs sdsd ", FileMode.Open)) {}
          }
          catch
          {
          }
          System.Console.WriteLine(GetLastError());
        }
      }
    }
 
