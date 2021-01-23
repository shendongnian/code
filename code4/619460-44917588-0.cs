        var s = new DataContractJsonSerializer(
                typeof(YourTypeToSerialize),
                new DataContractJsonSerializerSettings
                {
                    DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
                }
            );
