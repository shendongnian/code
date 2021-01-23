    public static String ToQueryString<ModelType> (this ModelType model) {
        return new ViewDataDictionary<ModelType>(model).ModelMetadata.ToQueryString();
    }
    public static String ToQueryString (this ModelMetadata modelMetadata) {
        if (modelMetadata.Model == null) {
            return String.Empty;
        }
        var parameters = modelMetadata.Properties.SelectMany(mm => mm.SelectPropertiesAsQueryStringParameters(null));
        return "?" + String.Join("&", parameters);
    }
    private static IEnumerable<String> SelectPropertiesAsQueryStringParameters (this ModelMetadata modelMetadata, String prefix) {
        if (modelMetadata.Model == null) {
            yield break;
        }
        if (modelMetadata.IsComplexType) {
            IEnumerable<String> parameters;
            if (typeof(IEnumerable).IsAssignableFrom(modelMetadata.ModelType)) {
                parameters = modelMetadata.GetItemMetadata()
                    .Select((mm, i) =>
                        new {
                            mm,
                            prefix = String.Format("{0}{1}[{2}]",
                                String.IsNullOrEmpty(prefix) ? String.Empty : prefix + ".",
                                modelMetadata.PropertyName,
                                i
                            )
                        }
                    )
                    .SelectMany(prefixed =>
                        prefixed.mm.SelectPropertiesAsQueryStringParameters(prefixed.prefix)
                    );
            }
            else {
                parameters = modelMetadata.Properties
                    .SelectMany(mm =>
                        mm.SelectPropertiesAsQueryStringParameters(
                            String.Format("{0}{1}", prefix, modelMetadata.PropertyName)
                        )
                    );
            }
            foreach (var parameter in parameters) {
                yield return parameter;
            }
        }
        else {
            yield return String.Format("{0}={1}",
                AntiXssEncoder.HtmlFormUrlEncode(
                    String.Concat(
                        prefix,
                        (!String.IsNullOrEmpty(prefix) && !String.IsNullOrEmpty(modelMetadata.PropertyName))
                            ? "."
                            : String.Empty,
                        modelMetadata.PropertyName
                    )
                ),
                AntiXssEncoder.HtmlFormUrlEncode(modelMetadata.Model.ToString())
            );
        }
    }
    // Returns the metadata for each item from a ModelMetadata.Model which is IEnumerable
    private static IEnumerable<ModelMetadata> GetItemMetadata (this ModelMetadata modelMetadata) {
        if (modelMetadata.Model == null) {
            yield break;
        }
        var genericType = modelMetadata.ModelType
            .GetInterfaces()
            .FirstOrDefault(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>));
        if (genericType == null) {
            yield return modelMetadata;
        }
        var itemType = genericType.GetGenericArguments()[0];
        foreach (Object item in ((IEnumerable) modelMetadata.Model)) {
            yield return ModelMetadataProviders.Current.GetMetadataForType(() => item, itemType);
        }
    }
