    static Func<string, TextBoxSettings> CreateTextBoxSettingsMethod()
    {
        return tbName =>
        {
            TextBoxSettings settings;
            switch (tbName) {
                case "textbox1":
                case "textbox2":
                case "textbox3":
                    settings = new TextBoxSettings {
                        TextBoxName = tbName,
                        ControlStyle = "editor",
                        ShowModelErrors = true
                    };
                    settings.Properties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText;
                    return settings;
                case "textbox4":
                case "textbox5":
                    settings = new TextBoxSettings {
                        TextBoxName = tbName,
                        ControlStyle = "displayer",
                        ShowModelErrors = false
                    };
                    settings.Properties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.TextOnly;
                    return settings;
                default:
                    return new TextBoxSettings { TextBoxName = tbName };
            }
        };
    }
