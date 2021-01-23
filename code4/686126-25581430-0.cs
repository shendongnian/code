    TextDecorationCollection decs = (TextDecorationCollection)theRTB.Selection.GetPropertyValue( Inline.TextDecorationsProperty );
    if (decs.Contains(TextDecorations.Underline[0]))
    {
        TextDecorationCollection noUnder = new TextDecorationCollection(decs);
        noUnder.Remove(TextDecorations.Underline[0]);  //this is a bool, and could replace Contains above
        theRTB.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, noUnder);
    }
