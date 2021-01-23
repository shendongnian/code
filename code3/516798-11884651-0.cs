            // MyType is a content type having StatePart attached
            var item = _contentManager.New("MyType");
            // Setting parts is possible directly like this.
            // NOTE that this is only possible if the part has a driver (even if it's empty)!
            item.As<StatePart>().StateName = "California";
            _contentManager.Create(item);
