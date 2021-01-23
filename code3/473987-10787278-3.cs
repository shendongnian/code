    if (ex.Message == "MyError")
    {
       string filename = String.Format("{1}_{0:yyyy-MM-dd}", @"log", DateTime.Now);
       string fullpath = Path.Combine(@"\",filename);
       using (StreamWriter sw = File.CreateText(path))
       {
          //This is where you will write your text to the new file if the other one was in use
          sw.WriteLine("something....");
       }
    }
