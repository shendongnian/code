        public void AddServer(string name)
        {
            ExceptionsIgnoredOnSave.Add(UniqueConstraintViolation);
            if (!context.Servers.Any(c => c.Name == name))
            {
                var server = context.Servers.Add(new Server { Name = name });
            }
        }
