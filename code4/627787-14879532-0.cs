		public static void ConvertBlToUi<TBl, TUi>(TBl entitySource, TUi entityTarget)
		{
			var blProperties = typeof(TBl).GetProperties().Select(p => new { Name = p.Name.ToLower(), Property = p }).ToArray();
			var uiProperties = typeof(TUi).GetProperties().Select(p => new { Name = p.Name.ToLower(), Property = p });
			foreach (var uiProperty in uiProperties)
			{
				var value = blProperty.Property.GetValue(entitySource);
                var t = Nullable.GetUnderlyingType(uiProperty.Property.PropertyType) ?? uiProperty.Property.PropertyType;
                var safeValue = (value == null) ? null : Convert.ChangeType(value, t);
                uiProperty.Property.SetValue(entityTarget, safeValue);
			}
		}
