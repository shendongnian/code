    Action<ItemViewModel, Item> MapDetailsAction = (source, destination) =>
            {
                if (destination.Details == null)
                {
                    destination.Details = new Details();
                    destination.Details =
                        Mapper.Map<ItemViewModel, Item>(
                        source.Details, destination.Details);
                }
            };
