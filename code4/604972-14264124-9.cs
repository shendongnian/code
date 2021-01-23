    static Func<string, TextBoxSettings> CreateTextBoxSettingsMethod(string txtBoxName)
    {
        switch (txtBoxName) {
            case "textbox1":
            case "textbox2":
            case "textbox3":
                return tbName =>
                {
                    var settings = new TextBoxSettings {
                        TextBoxName = tbName,
                        ControlStyle = "editor",
                        ShowModelErrors = true
                    };
                    settings.Properties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText;
                    return settings;
                };
            case "textbox4":
            case "textbox5":
                return tbName =>
                {
                    var settings = new TextBoxSettings {
                        TextBoxName = tbName,
                        ControlStyle = "displayer",
                        ShowModelErrors = false
                    };
                    settings.Properties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.TextOnly;
                    return settings;
                };
            default:
                return tbName => new TextBoxSettings { TextBoxName = tbName };
        }
    }
