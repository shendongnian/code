	internal void WriteAttributes(TextWriter outText, bool closing)
	{
        if (Name.StartsWith("?"))
        {
            int len = _outerlength - 3 - _namelength;
            if (len > 0)
            {
                outText.Write(OwnerDocument.Text.Substring(_namestartindex + _namelength, len));
                return;
            }
        }
        ....
    }
