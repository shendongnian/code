    string content;
    using (var reader = new StreamReader(stream))
        content = reader.ReadToEnd();
    // Process content here.
    string line;
    using (var reader = new StringReader(content))
        while ((line = reader.ReadLine()) != null)
            Console.WriteLine(line);
