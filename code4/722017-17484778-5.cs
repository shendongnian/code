    foreach( WebControl c in FindRecursive( Page, c => (c is WebControl) && 
                               ((WebControl)c).CssClass == "test" ) )
    {
        //Code
    }
