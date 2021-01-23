    /* Okay, sorry I didn't have more time for this the other day.
     * But there is a very simple/eloquent solution for this that will
     * leave you wondering why you didn't think of it. AND...
     * Such is programming LoL.
    */
    // Say I have existing code something like:
    PrintFont = PrintMasterSettings.Default.PrintFont;
    /* 
    * Where PrintSettings.Default.PrintFont is persistent storage for PrintFont.
    * Fine & dandy. The PrintFont gets brought back in, size, style, everything
    * BUT The Script Selection. Am I close to the problem a lot of people have
    * here Much YET?  ROFL. And try as you might you can't SET; the GdiCharSet
    * value Because _fontDialog.Font.GdiCharSet has no SETTER. Right?  Been
    * there done much more than that. No t-shirt... but I did figure it out in
    * about ten minutes after sleeping on it.
    *
    * What to charge for the answer and who to sell it to?  LOL. Give up yet???
    * Well, I have an "advantage" in that I'm self-taught. Think out of that box
    * most programming profs have never done much programming. True fact.
    * So how to do it is alluding you because you are trying to do it the
    * "right way" and, instead, should be focused on doing it period.
    *
    * "Some way, GdiCharSet my ***; MAKE IT GD work!" the boss said. 
    * "Searching StackOverflow says it can't be done." I said. 
    * "Prove them wrong!" he said. "If you buy lunch?" I said with finality.
    * "Fine!" he said. ***I had a Nice thick and rare New York steak!
    *
    */
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
