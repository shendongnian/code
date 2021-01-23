    // Prefer casting over "as" unless you're going to check it...
    using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
    {
        using (Stream stream = response.GetResponseStream())
        {
            // For diagnostics, let's assume UTF-8
            using (StreamReader reader = new StreamReader(stream))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
