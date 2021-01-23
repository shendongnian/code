    ItemType newItem = xmlParser.LoadItem(); //info for newItem takes from xml
            newItem.ExtendedProperty = new ExtendedPropertyType[1];
            PathToExtendedFieldType q = new PathToExtendedFieldType();
            q.PropertyTag = "3590"; //DeliveryTime
            q.PropertyType = MapiPropertyTypeType.SystemTime;
            newItem.ExtendedProperty[0] = new ExtendedPropertyType();
            newItem.ExtendedProperty[0].ExtendedFieldURI = q;
            newItem.ExtendedProperty[0].Item = new System.DateTime(2014, 5, 5, 5, 5, 5).ToString("yyyy-MM-ddTHH:mm:ssZ");
