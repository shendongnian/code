    using System;
    using System.Text;
    
    public class MainClass
    {
      [DllImport("kernel32")]
      private static extern long WritePrivateProfileString(string section,
        string key, string val, string filePath);
      [DllImport("kernel32")]
      private static extern int GetPrivateProfileString(string section,
        string key, string def, StringBuilder retVal,
        int size, string filePath);
    
      static void Main()
      {
        StringBuilder asdf = new StringBuilder();
        GetPrivateProfileString("global","test","",asdf,100,@"c:\example\test.ini");
        Console.WriteLine(asdf.ToString());
      }
    }
