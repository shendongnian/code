        var ordered = input.OrderBy(...);
        // This is like using foreach, but with a simple way to get the
        // first item
        using (var iterator = ordered.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                return; // Or whatever. No items!
            }
            var previousProperty = iterator.Current.Property;
            while (iterator.MoveNext())
            {
                var currentProperty = iterator.Current.Property;
                if (previousProperty == currentProperty)
                {
                    ... Whatever you want to do
                }
                previousProperty = currentProperty;
            }
        }
        
