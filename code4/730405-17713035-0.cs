        using (var reader = parsedXML.CreateReader()) {
            if (serializer.CanDeserialize(reader))
            {
                    **--This is where everything gets stuck--**
                dto = (T)serializer.Deserialize(reader);
            }
        }
