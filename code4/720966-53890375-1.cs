    BooleanProperty boolProp = new BooleanProperty();
	// boolProp.getValue() => returns a bool
	DateTimeProperty dateTimeProp = new DateTimeProperty();
	// dateTimeProp.getValue(); => returns a DateTime
    _myProperties.Add((IProperty<object>)boolProp);
    _myProperties.Add((IProperty<object>)dateTimeProp);
