           public static IHtmlString CheckBoxesForEnumFlagsFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
           {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            Type enumModelType = metadata.ModelType;
            // Check to make sure this is an enum.
            if (!enumModelType.IsEnum)
            {
                throw new ArgumentException("This helper can only be used with enums. Type used was: " + enumModelType.FullName.ToString() + ".");
            }
            // Create string for Element.
            var sb = new StringBuilder();
            foreach (Enum item in Enum.GetValues(enumModelType))
            {
                if (Convert.ToInt32(item) != 0)
                {
                    var ti = htmlHelper.ViewData.TemplateInfo;
                    var id = ti.GetFullHtmlFieldId(item.ToString());
                    var name = ti.GetFullHtmlFieldName(string.Empty);
                    var label = new TagBuilder("label");
                    label.Attributes["for"] = id;
                    var field = item.GetType().GetField(item.ToString());
                    // Add checkbox.
                    var checkbox = new TagBuilder("input");
                    checkbox.Attributes["id"] = id;
                    checkbox.Attributes["name"] = name;
                    checkbox.Attributes["type"] = "checkbox";
                    checkbox.Attributes["value"] = item.ToString();
                    var model = htmlHelper.ViewData.Model as Enum;
                    if (model.HasFlag(item))
                    {
                        checkbox.Attributes["checked"] = "checked";
                    }
                    sb.AppendLine(checkbox.ToString());
                    // Check to see if DisplayName attribute has been set for item.
                    var displayName = field.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                        .FirstOrDefault() as DisplayNameAttribute;
                    if (displayName != null)
                    {
                        // Display name specified.  Use it.
                        label.SetInnerText(displayName.DisplayName);
                    }
                    else
                    {
                        // Check to see if Display attribute has been set for item.
                        var display = field.GetCustomAttributes(typeof(DisplayAttribute), true)
                            .FirstOrDefault() as DisplayAttribute;
                        if (display != null)
                        {
                            label.SetInnerText(display.Name);
                        }
                        else
                        {
                            label.SetInnerText(item.ToString());
                        }
                    }
                    sb.AppendLine(label.ToString());
                    // Add line break.
                    sb.AppendLine("<br />");
                }                
            }
            return new HtmlString(sb.ToString());
           }
