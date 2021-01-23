        foreach (var oldSetList in OldAppSetting)
        {
            Document = Document = XDocument.Load(@oldSetList.FilePathProp);
            var appSetting = Document.Descendants("add").Select(add => new
            {
                Key = add.Attribute("key"),
                Value = add.Attribute("value")
            }).ToArray();
            foreach (var oldSet in appSetting)
            {
                foreach (var newSet in NewAppSetting)
                {
                    if (oldSet.Key != null)
                    {
                        if (oldSet.Key.Value == newSet.AppKey)
                        {
                            oldSet.Value.Value = newSet.AppValue;
                        }
                    }
                }
            }
            Document.Save(@oldSetList.FilePathProp);
        }
