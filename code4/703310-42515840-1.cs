    public string ApplicationTitle
            {
                get
                {
                    var text = "Application Name";
                    if (!string.IsNullOrEmpty(_currentFileLoaded))
                    {
                        text += $" ({_currentFileLoaded})";
                    }
    
                    return text;
                }
            }
