    class Program
    {
        static void Main(string[] args)
        {
            string sourcedirectory = @"C:\source";
            string destinationdirectory = @"C:\destination";
            string backupdirectory = @"C:\Backup";
            try
            {
                if (Directory.Exists(sourcedirectory))
                {
                    if (Directory.Exists(destinationdirectory))
                    {
                        //Directory.Delete(destinationdirectory);
                        Directory.Move(destinationdirectory, backupdirectory + DateTime.Now.ToString("_MMMdd_yyyy_HHmmss"));
                        Directory.Move(sourcedirectory, destinationdirectory);
                    }
                    else
                    {
                        Directory.Move(sourcedirectory, destinationdirectory);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
