    //Store all filenames within a List<string>
    public void ReadFiles(List<string> filenames)
    {
        string line = null;
        foreach(string file in filenames)
        {
            //The using will manage the closing and handle exceptions safely
            using(StreamReader reader = new StreamReader(file))
            {
                while((line = reader.readLine()) != null)
                Console.WriteLine(line);
            }
            if(File.Exists(file))
                File.Delete(file);
        }
    }
