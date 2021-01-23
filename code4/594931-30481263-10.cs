    public static class QueryStringExtensions {
        #region inner types
        private struct PrefixedModelMetadata {
            public readonly String Prefix;
            public readonly ModelMetadata ModelMetadata;
            public PrefixedModelMetadata (String prefix, ModelMetadata modelMetadata) {
                Prefix = prefix;
                ModelMetadata = modelMetadata;
            }
        }
        #endregion
        #region fields
        private static readonly Type IEnumerableType = typeof(IEnumerable),
                                     IEnumerableGenericType = typeof(IEnumerable<>);
        #endregion
        #region methods
        public static String ToQueryString<ModelType> (this ModelType model) {
            return new ViewDataDictionary<ModelType>(model).ModelMetadata.ToQueryString();
        }
        public static String ToQueryString (this ModelMetadata modelMetadata) {
            if (modelMetadata.Model == null) {
                return String.Empty;
            }
            var keyValuePairs = modelMetadata.Properties.SelectMany(mm =>
                mm.SelectPropertiesAsQueryStringParameters(new List<String>())
            );
            return String.Join("&", keyValuePairs.Select(kvp => String.Format("{0}={1}", kvp.Key, kvp.Value)));
        }
        private static IEnumerable<KeyValuePair<String, String>> SelectPropertiesAsQueryStringParameters (this ModelMetadata modelMetadata, List<String> prefixChain) {
            if (modelMetadata.Model == null) {
                yield break;
            }
            if (modelMetadata.IsComplexType) {
                IEnumerable<KeyValuePair<String, String>> keyValuePairs;
                if (IEnumerableType.IsAssignableFrom(modelMetadata.ModelType)) {
                    keyValuePairs = modelMetadata.GetItemMetadata().Select((mm, i) =>
                        new PrefixedModelMetadata(
                            modelMetadata: mm,
                            prefix: String.Format("{0}[{1}]", modelMetadata.PropertyName, i)
                        )
                    ).SelectMany(prefixed => prefixed.ModelMetadata.SelectPropertiesAsQueryStringParameters(
                        prefixChain.ToList().AddChainable(prefixed.Prefix, addOnlyIf: IsNeitherNullNorWhitespace)
                    ));
                }
                else {
                    keyValuePairs = modelMetadata.Properties.SelectMany(mm =>
                        mm.SelectPropertiesAsQueryStringParameters(
                            prefixChain.ToList().AddChainable(
                                modelMetadata.PropertyName,
                                addOnlyIf: IsNeitherNullNorWhitespace
                            )
                        )
                    );
                }
                foreach (var keyValuePair in keyValuePairs) {
                    yield return keyValuePair;
                }
            }
            else {
                yield return new KeyValuePair<String, String>(
                    key: AntiXssEncoder.HtmlFormUrlEncode(
                        String.Join(".",
                            prefixChain.AddChainable(
                                modelMetadata.PropertyName,
                                addOnlyIf: IsNeitherNullNorWhitespace
                            )
                        )
                    ),
                    value: AntiXssEncoder.HtmlFormUrlEncode(modelMetadata.Model.ToString()));
            }
        }
        // Returns the metadata for each item from a ModelMetadata.Model which is IEnumerable
        private static IEnumerable<ModelMetadata> GetItemMetadata (this ModelMetadata modelMetadata) {
            if (modelMetadata.Model == null) {
                yield break;
            }
            var genericType = modelMetadata.ModelType.GetInterfaces().FirstOrDefault(x =>
                x.IsGenericType && x.GetGenericTypeDefinition() == IEnumerableGenericType
            );
            if (genericType == null) {
                yield return modelMetadata;
            }
            var itemType = genericType.GetGenericArguments()[0];
            foreach (Object item in ((IEnumerable) modelMetadata.Model)) {
                yield return ModelMetadataProviders.Current.GetMetadataForType(() => item, itemType);
            }
        }
        private static List<T> AddChainable<T> (this List<T> list, T item, Func<T, Boolean> addOnlyIf = null) {
            if (addOnlyIf != null && addOnlyIf(item)) {
                list.Add(item);
            }
            return list;
        }
        private static Boolean IsNeitherNullNorWhitespace (String value) {
            return !String.IsNullOrWhiteSpace(value);
        }
        #endregion
    }
