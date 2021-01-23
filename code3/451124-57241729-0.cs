            var removedItems = new List<Example>();
            list.RemoveAll(x =>
            {
                if (x.Condition)
                {
                    removedItems.Add(x);
                    return true;
                }
                return false;
            });
