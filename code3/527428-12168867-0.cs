    string appPath = Path.GetDirectoryName(Application.ExecutablePath);
    string fname = projectNameBox.Text;
    
    bool _isValid = true;
    foreach (char c in Path.GetInvalidFileNameChars())
    {
        if (projectNameBox.Text.Contains(c))
        {
            _isValid = false;
            break;
        }
    }
    
    if (!string.IsNullOrEmpty(projectNameBox.Text) && _isValid)
    {
        File.Create(appPath + "\\projects\\" + fname + ".wtsprn");
    }
    else
    {
        MessageBox.Show("Invalid file name.", "Error");
    }
