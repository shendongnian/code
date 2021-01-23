    public Stream LoadStreamSample(Stream ms)
    {
        using (StreamWriter sw = new StreamWriter(ms, Encoding.UTF8)){
            // Call SQL and iterate over rows from SqlDataReader here...
            while (dr.Read()){
                // replace following with csv of one record
                string csv = "Hello, World\nGoodBye, For, Now\n";
                sw.WriteLine(csv)
            }
        }
        return ms;
    }
