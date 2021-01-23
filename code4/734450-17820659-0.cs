static void Main(string[] args)
{
   string path = Path.GetFullPath(@"C:\Users\Me\Desktop\elloBatch.bat");
   if(File.Exists(path))
   {
      ProcessStartInfo proc = new ProcessStartInfo(path);
      Process.Start(proc);
   }
   else
   {
      Console.Write("File not at specified location.");
   }
}
