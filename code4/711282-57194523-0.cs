        public IEnumerable<Component> GetComponents(Control c)
        {
            FieldInfo fi = c.GetType()
                .GetField("components", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (fi?.GetValue(c) is IContainer container)
            {
                return container.Components.OfType<Component>();
            }
            else
            {
                return Enumerable.Empty<Component>();
            }
        }
