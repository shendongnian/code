    void ListDirectories(string path, StringBuilder sb)
    {
        var directories = Directory.GetDirectories(path);
        if (directories.Any())
        {
            sb.AppendLine("<ul>");
            foreach (var directory in directories)
            {
                var di = new DirectoryInfo(directory);
                sb.AppendFormat("<li>{0}</li>", di.Name);
                sb.AppendLine();
                ListDirectories(directory, sb);
            }
            sb.AppendLine("</ul>");
        }
    }
