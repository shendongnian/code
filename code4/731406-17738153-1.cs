    String clipboardText = Clipbard.GetText( );
    // MAXPASTELENGTH - max length allowed by your program
    if(clipboardText.Length > MAXPASTELENGTH)
    {
       Clipboard.Clear(); 
       String newClipboardText = clipboardText.Substring(0, MAXPASTELENGTH);
       // set the new clipboard data to the max length 
       SetData(DataFormats.Text, (Object)newClipboardText );
    }
