    p.StartInfo.RedirectStandardOutput = true;
    //p.WaitForExit();
    StringBuilder value = new StringBuilder();
    while ( ! p.HasExited ) {
        value.Append(p.StandardOutput.ReadToEnd());
    }
    string result = value.ToString();
