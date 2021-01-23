    // in code-behind
    this.litMyText.Text = AddSuper( "1st" );
    // a few test cases (also demonstrates processing multiple items)
    // should match
    var testValues = new[] { "1st", "2nd", "10th", "20th", "1000th", "3rd", "19th" };
    foreach( string val in testValues ) {
        Response.Write( AddSuper( val ) );
    }
    // should not match
    testValues = new[] { "test", "nd", "fourth", "25", "hello world th", "15,things", "1 1 1thousand" };
    foreach( string val in testValues ) {
        Response.Write( AddSuper( val ) );
    }
