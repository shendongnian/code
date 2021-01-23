		public delegate object Property<T>(T property);
		public static HtmlString MultiSelectListFor<TModel, TKey, TProperty>(
			this HtmlHelper<TModel> htmlHelper,
			Expression<Func<TModel, IEnumerable<TKey>>> forExpression,
			IEnumerable<TProperty> enumeratedItems,
			Func<TProperty, TKey> idExpression,
			Property<TProperty> displayExpression,
			Property<TProperty> titleExpression,
			object htmlAttributes) where TModel : class
		{
			//initialize values
			var metaData = ModelMetadata.FromLambdaExpression(forExpression, htmlHelper.ViewData);
			var propertyName = metaData.PropertyName;
			var propertyValue = htmlHelper.ViewData.Eval(propertyName).ToStringOrEmpty();
			var enumeratedType = typeof(TProperty);
			//check for problems
			if (enumeratedItems == null) throw new ArgumentNullException("The list of items cannot be null");
			//build the select tag
			var returnText = string.Format("<select multiple=\"multiple\" id=\"{0}\" name=\"{0}\"", HttpUtility.HtmlEncode(propertyName));
			if (htmlAttributes != null)
			{
				foreach (var kvp in htmlAttributes.GetType().GetProperties()
				 .ToDictionary(p => p.Name, p => p.GetValue(htmlAttributes, null)))
				{
					returnText += string.Format(" {0}=\"{1}\"", HttpUtility.HtmlEncode(kvp.Key),
					 HttpUtility.HtmlEncode(kvp.Value.ToStringOrEmpty()));
				}
			}
			returnText += ">\n";
			//build the options tags
			foreach (TProperty listItem in enumeratedItems)
			{
				var idValue = idExpression(listItem).ToStringOrEmpty();
				var displayValue = displayExpression(listItem).ToStringOrEmpty();
				var titleValue = titleExpression(listItem).ToStringOrEmpty();
				returnText += string.Format("<option value=\"{0}\" title=\"{1}\"",
					HttpUtility.HtmlEncode(idValue), HttpUtility.HtmlEncode(titleValue));
				if (propertyValue.Contains(idValue))
				{
					returnText += " selected=\"selected\"";
				}
				returnText += string.Format(">{0}</option>\n", HttpUtility.HtmlEncode(displayValue));
			}
			//close the select tag
			returnText += "</select>";
			return new HtmlString(returnText);
		}
