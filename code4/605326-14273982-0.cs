    var fooEntity =GetFooByID(999);
    
    if (fooEntity != null) {
        var barEntity = new Bar() {
            Sweetness = 8,
            Bitterness = 5,
            // goes on...
        };
        SaveBarEntity(barEntity); 
        SaveFooEntity(fooEntity); // If necessary, do something to make sure EF performs an update
    }
