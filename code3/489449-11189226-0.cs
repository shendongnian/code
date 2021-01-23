    public string ParseFile<T>(string fileName, T model) {
        var file = File.OpenText(fileName);
        var sb = new StringBuilder();
        string line;
        while ((line = file.ReadLine()) != null)
        {
            // RazorEngine does not recognize the @model line, remove it
            if (!line.StartsWith("@model ", StringComparison.OrdinalIgnoreCase))
                sb.AppendLine(line);
            }
            file.Close();
            // Stuff to make sure we get unescaped-Html back:
            var config = new FluentTemplateServiceConfiguration(
                        c => c.WithEncoding(RazorEngine.Encoding.Raw));
            string result;
            using (var service = new TemplateService(config))
            {
                return service.Parse<T>(sb.ToString(), model);
            }
        }
    }
