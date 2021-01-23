    public static class ModelMetadataExtensions
    {
        public static string GetName<TModel, TProperty>(this TModel model, Expression<Func<TModel, TProperty>> ex)
        {
            return ModelMetadata
                .FromLambdaExpression<TModel, TProperty>(ex, new ViewDataDictionary<TModel>(model))
                .DisplayName;
        }
    }
