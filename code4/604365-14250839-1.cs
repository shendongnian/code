    using(StreamWriter writer = new StreamWriter(Response.OutputStream))
    {
        writer.WriteLine("col1,col2,col3");
        writer.WriteLine("1,2,3");
        writer.Close(); //not necessary I think... end of using block should close writer
    }
