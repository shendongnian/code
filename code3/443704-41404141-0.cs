    // Okay, So now I simply call my special custom method like so:
    PrintFont = GetFontWithScript();
    // Okay, I mean don't feel dumb. Things don't always work in .NET...
    // NOT like you'd think they should. But there is usually a simple way.
    // I'm thinking it's an indexer to a collection right. But no it's just as
    // Gd simple. LoL  Enjoy! (yes, this really works. The initial value for
    // PrintSettings.Default.GdiCharSet should be set to 1 btw.)
    // Then somewhere before your _fontDialog.ShowDialog(); you have:
    _fontDialog.Font = PrintFont;
    // Right...  But the big money is in the method. Check in the mail? LoL
    // Promise you won't feel dumb? Because you're not, you made it to here!
    // You searched it and found someone who knew. That's pretty smart!
    // Nobody around here even knows what I'm on about mate. G'day.
    // JpE@ facebook-dot-com/JpESystems/
    // Okay here it is... This should help a lot of peeps. 
    // Please mark This ANSWER AS USEFUL if it helps you guys and gals out.
    //\\//\\//\\//\\//\\//\\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\
    private Font GetFontWithScript()
    {
      PrintFont   = PrintMasterSettings.Default.PrintFont;
      var name    = PrintFont.Name;
      var size    = PrintFont.Size;
      var style   = PrintFont.Style;
      var unit    = PrintFont.Unit;
      var charSet = PrintMasterSettings.Default.GdiCharSet;// byte value btw.
      return new Font(name,size,style,unit,charSet);
      /*
      * Font(String, Single, FontStyle, GraphicsUnit, Byte)	
      * Initializes a new Font using a specified size, style, 
      * unit and character set.
      * 
      */
    }
