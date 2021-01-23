    public void SplitFile()
    {
        int nr = 1;
        int package = 300;
        DateTime date2 = DateTime.Now;
        int packtester = 0;
        using (var freader = new StreamReader("bigfile.txt"))
        {
            StreamWriter pak = null;
            try
            {
                pak = new StreamWriter(GetPackFilename(package, nr, date2), false);
                string line;
                while ((line = freader.ReadLine()) != null)
                {
                    if (packtester < package)
                    {
                        pak.WriteLine(line); //writing line to small file
                        packtester++; //increasing the lines of small file
                    }
                    else
                    {
                        pak.Flush();
                        pak.Close(); //closing the file
                        packtester = 0;
                        nr++; //nr++ -> just for file name to be Pack-2;
                        pak = new StreamWriter(GetPackFilename(package, nr, date2), false);
                    }
                }
            }
            finally
            {
                if(pak != null)
                {
                    pak.Dispose();
                }
            }
        }
    }
    private string GetPackFilename(int package, int nr, DateTime date2)
    {
        return string.Format("{0}Pack-{1}+_{2}.txt", package, nr, date2);
    }
