    foreach (var property in GetType().GetProperties())
            {
                if (!typeof(IComparableProperty).IsAssignableFrom(property.PropertyType)) continue;
                var compareTo = target.GetType().GetProperty(property.Name).GetValue(target, null) as IComparableProperty;
                var local = property.GetValue(this, null) as IComparableProperty;
                if (local == null) continue;
                return local.IsBetterThan(compareTo);
            }
