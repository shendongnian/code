    public virtual void Map(ModelMapper mapper)
        {
            mapper.Class<LocalizationEntry>(m =>
            {
                m.ComponentAsId(x => x.Id, n =>
                {
                    n.Property(x => x.Culture);
                    n.Property(x => x.EntityId);
                    n.Property(x => x.Property);
                    n.Property(x => x.Type);
                });
                m.Property(t => t.Message, c =>
                {
                    c.NotNullable(true);
                    c.Length(400);
                });
            });
        }
