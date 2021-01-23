            foreach (Item item in items.Items)
            {
                foreach (var ext in item.ExtendedProperties)
                {
                    // check if the extended property is from this contact
                    if (c.Id.ChangeKey == item.Id.ChangeKey)
                    {
                        extendedProperties.Add(ext);
                    }
                }
            }
