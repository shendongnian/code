        public class EntityListToModelListConverter<TEntity, TModel>
        {
            public List<TModel> Convert(IList<TEntity> from, object state)
            {
                if (from == null)
                    return null;
                var models = new List<TModel>();
                var mapper = ObjectMapperManager.DefaultInstance.GetMapper<TEntity, TModel>();
                for (int i = 0; i < from.Count(); i++)
                {
                    models.Add(mapper.Map(from.ElementAt(i)));
                }
                return models;
            }
        }
