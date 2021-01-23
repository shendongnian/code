    StringBuilder content = new StringBuilder();
    while ( ! p.HasExited ) {
        content.Append(p.StandardOutput.ReadToEnd());
    }
    string output = content.ToString();
