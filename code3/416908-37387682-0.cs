    public static class Extensions
    {
        public static IHtmlString CheckBoxesForEnumFlagsFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            Type enumModelType = metadata.ModelType;
            var isEnum = enumModelType.IsEnum;
            var isNullableEnum = enumModelType.IsGenericType &&
                                 enumModelType.GetGenericTypeDefinition() == typeof (Nullable<>) &&
                                 enumModelType.GenericTypeArguments[0].IsEnum;
            // Check to make sure this is an enum.
            if (!isEnum && !isNullableEnum)
            {
                throw new ArgumentException("This helper can only be used with enums. Type used was: " + enumModelType.FullName.ToString() + ".");
            }
            // Create string for Element.
            var sb = new StringBuilder();
            Type enumType = null;
            if (isEnum)
            {
                enumType = enumModelType;
            }
            else if (isNullableEnum)
            {
                enumType = enumModelType.GenericTypeArguments[0];
            }
            foreach (Enum item in Enum.GetValues(enumType))
            {
                if (Convert.ToInt32(item) != 0)
                {
                    var ti = htmlHelper.ViewData.TemplateInfo;
                    var id = ti.GetFullHtmlFieldId(item.ToString());
                    //Derive property name for checkbox name
                    var body = expression.Body as MemberExpression;
                    var propertyName = body.Member.Name;
                    var name = ti.GetFullHtmlFieldName(propertyName);
                    //Get currently select values from the ViewData model
                    //TEnum selectedValues = expression.Compile().Invoke(htmlHelper.ViewData.Model);
                    var label = new TagBuilder("label");
                    label.Attributes["for"] = id;
                    label.Attributes["style"] = "display: inline-block;";
                    var field = item.GetType().GetField(item.ToString());
                    // Add checkbox.
                    var checkbox = new TagBuilder("input");
                    checkbox.Attributes["id"] = id;
                    checkbox.Attributes["name"] = name;
                    checkbox.Attributes["type"] = "checkbox";
                    checkbox.Attributes["value"] = item.ToString();
                    var model = (metadata.Model as Enum);
                    //var model = htmlHelper.ViewData.Model as Enum; //Old Code
                    if (model != null && model.HasFlag(item))
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
    }
 
    public class FlagEnumerationModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext == null) throw new ArgumentNullException("bindingContext");
            if (bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName))
            {
                var values = GetValue<string[]>(bindingContext, bindingContext.ModelName);
                if (values.Length > 1 && (bindingContext.ModelType.IsEnum && bindingContext.ModelType.IsDefined(typeof(FlagsAttribute), false)))
                {
                    long byteValue = 0;
                    foreach (var value in values.Where(v => Enum.IsDefined(bindingContext.ModelType, v)))
                    {
                        byteValue |= (int)Enum.Parse(bindingContext.ModelType, value);
                    }
                    return Enum.Parse(bindingContext.ModelType, byteValue.ToString());
                }
                else
                {
                    return base.BindModel(controllerContext, bindingContext);
                }
            }
            return base.BindModel(controllerContext, bindingContext);
        }
        private static T GetValue<T>(ModelBindingContext bindingContext, string key)
        {
            if (bindingContext.ValueProvider.ContainsPrefix(key))
            {
                ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(key);
                if (valueResult != null)
                {
                    bindingContext.ModelState.SetModelValue(key, valueResult);
                    return (T)valueResult.ConvertTo(typeof(T));
                }
            }
            return default(T);
        }
    }
