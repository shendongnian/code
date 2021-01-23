    var properties =
                    item.GetType().GetProperties()
                                    .Where(p => p.GetCustomAttributes(true)
                                                .OfType<IncludeInEditorAttribute>()
                                                .Any())
                                    .Select(x => new
                                    {
                                        Property = x,
                                        Attribute = Attribute.GetCustomAttribute(x, typeof(IsInPkAttribute), true)
                                                        ?? Attribute.GetCustomAttribute(x, typeof(IncludeInEditorAttribute), true)
                                    })
                                    .OrderBy(x => x.Attribute, new IncludeInEditorAttributeComparer())
                                    .Select(x => x.Property)
                                    .ToArray();
