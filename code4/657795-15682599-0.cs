    Stream stream = response.GetResponseStream();
    Stream cleanStream = new Stream();
    using (StreamWriter writer = new StreamWriter(cleanStream))
    {
        using (StreamReader reader = new StreamReader(stream))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // if the line doesn't match the problem then write it to the stream like this
                writer.WriteLine(line);
            }
        }
    }
    // and now use the cleanStream instead
    XmlTextReader xmlTextReader = new XmlTextReader(cleanStream);
