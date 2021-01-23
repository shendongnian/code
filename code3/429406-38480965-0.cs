    protected override void OnKeyDown(KeyEventArgs e)
    {
    ...
        var acceptedChars = false;
        // AcceptedChars is a String Property with all chars that this textBox should accept
        
        KeysConverter kc = new KeysConverter();
        string keyChar = kc.ConvertToString(e.KeyData);
        foreach (var acceptedChar in AcceptedChars.ToCharArray())
        {
            if (acceptedChar == Convert.ToChar(keyChar))
            {
                acceptedChars = true;
                break;
            }
        }
    ...
    }
    
