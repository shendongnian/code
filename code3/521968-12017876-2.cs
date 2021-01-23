    // simplified example
    private static readonly Regex _regex = new Regex( @"^\d{1}(st|nd|rd|th)$", RegexOptions.Compiled );
    public static string AddSuper( string value ){
       return // replace the captured group with "<sup>value</sup>";
    }
    // in code-behind
    this.litMyText.Text = AddSuper( "1st" );
