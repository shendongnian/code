                var toplevel = doc.Root.Elements().Select(settingElement => new Setting
                    {
                        Type = settingElement.Name.LocalName,
                        SettingItems = settingElement.Elements("Item").Select(itemElement => new SettingItem
                            {
                                Name = itemElement.Attribute("name").Value,
                                Value = itemElement.Attribute("value").Value,
                            })
                    }).ToList();
