    using System.IO;
    using System;
    public class X
    {
        public class Bitmap : IDisposable { 
            public void Dispose() { } 
            public void Save(string location)
            {
                Console.WriteLine("Saving: {0}", location);
                using (var s = new StreamWriter(location))
                    s.WriteLine("hello world");
            }
        }
        private static void saveAsync(Bitmap bitmap, String path, String fileName, int requestNo)
        {
            Action a = () =>
              {
                  var fmt = Path.Combine(path, Path.GetFileNameWithoutExtension(fileName)) + "_modified{0}" + Path.GetExtension(fileName);
                  int counter = 1;
                  string newName;
                  do {
                      newName = string.Format(fmt, counter++);
                  }
                  while (File.Exists(newName));
                  using (bitmap)
                      bitmap.Save(newName);
              };
            a();
            a();
            a();
            a();
        }
        public static void Main()
        {
            saveAsync(new Bitmap(), "/tmp/", "foo.png", 3);
        }
    }
