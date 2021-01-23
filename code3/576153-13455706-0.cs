    private static void WriteToFile(string s)
    {
        try
        {
            using (var stream = File.AppendText(@"c:\ErrorLog.txt"))
            {
                stream.WriteLine(s);
                stream.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("error writing to file: " + e);
            //...or any other means of external debug...
        }
    }
