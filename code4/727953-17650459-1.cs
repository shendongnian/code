    var attribType = typeof(DisplayAttribute);
    var cab = new CustomAttributeBuilder(
        attribType.GetConstructor(Type.EmptyTypes), // constructor selection
        new object[0], // constructor arguments - none
        new[] { // properties to assign to
            attribType.GetProperty("Order"),
            attribType.GetProperty("ResourceType"),
            attribType.GetProperty("Name"),
        },
        new object[] { // values for property assignment
            28,
            typeof(CommonResources),
            "DisplayComment"
        });
    prop.SetCustomAttribute(cab);
