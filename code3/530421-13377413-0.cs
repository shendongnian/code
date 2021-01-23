    public class LocalizationManager
    {
        public IDictionary<string, Localization> LostInTranslation()
        {
            var input = new[]
                            {
                                new Text {Key = "ORDINAL_1", LanguageId = "En", Value = "first"},
                                new Text {Key = "ORDINAL_1", LanguageId = "Fr", Value = "premier"},
                                new Text {Key = "ORDINAL_1", LanguageId = "De", Value = "erste"},
                                new Text {Key = "ORDINAL_2", LanguageId = "En", Value = "second"},
                                new Text {Key = "ORDINAL_2", LanguageId = "Fr", Value = "deuxième"},
                                new Text {Key = "ORDINAL_2", LanguageId = "De", Value = "zweite"},
                                new Text {Key = "ORDINAL_3", LanguageId = "En", Value = "third"},
                                new Text {Key = "ORDINAL_3", LanguageId = "Fr", Value = "troisième"},
                                new Text {Key = "ORDINAL_3", LanguageId = "De", Value = "dritte"},
                            };
            var output =
                input.GroupBy(text => text.Key).Select(
                    group =>
                    group.Aggregate(new Localization { Key = group.Key },
                                    (translation, text) =>
                                        {
                                            translation.GetType().GetProperty(text.LanguageId).SetValue(translation, text.Value, null);
                                            return translation;
                                        }));
            return output.ToDictionary(key => key.Key);
        }
    }
    public class Text
    {
        public string Key { get; set; }
        public string LanguageId { get; set; }
        public string Value { get; set; }
    }
    public class Localization
    {
        public string Key { get; set; }
        public string En { get; set; }
        public string De { get; set; }
        public string Fr { get; set; }
    }
