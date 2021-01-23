        StringBuilder sb = new StringBuilder();
        using (var stream = this.GetType().Assembly.GetManifestResourceStream("MyNamespace.TextFile.txt"))
        using(var reader = new StreamReader(stream))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                sb.AppendLine(line);
            }
        }
        ViewModel.Text = sb.ToString();
