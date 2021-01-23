    dynamic New = Builder.New<ExpandoObject>();
    
    dynamic dyn = New.Obj(
            Text: "Test",
            SubItem: New.Obj(
                SubText: "Bla",
                SubSub: New.Obj(
                    SubSubText: "Baha"
                )
            )
        );
