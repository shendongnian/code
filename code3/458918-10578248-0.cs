    // get the date the editor will work with, or use today's date if it is null
    DateTime workingDate = Model ?? DateTime.Now; 
    // was the model value nullable.  We handle both, but they can pass us a
    // non-nullable model property, and the editor should act differently
    bool isNullable = ViewData.ModelMetadata.IsNullableValueType;
 
    // get the min date passed in as optional params.  default to some reasonable timeframe
    var minDate = ViewBag.MinDate ?? DateTime.Now.AddDays(-30)
    // now start drawing the editor
