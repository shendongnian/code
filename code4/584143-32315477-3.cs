     CoreWindow.GetForCurrentThread().CharacterReceived += TextBox_CharacterReceived;
     void TextBox_CharacterReceived(CoreWindow sender, CharacterReceivedEventArgs args)
        {
            char c = Convert.ToChar(args.KeyCode);
            if (char.IsLetter(c))
            {
               ...
            }
        }
