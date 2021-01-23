		public override System.Data.Common.DbCommand CreateUpdateCommand(object o, object key)
		{
			var expando = o.ToExpando();
			var settings = (IDictionary<string, object>)expando;
			if (RemoveColumn)
			{
				if (settings.ContainsKey(ColumnToRemove))
					settings.Remove(ColumnToRemove);
			}
			return base.CreateUpdateCommand(settings, key);
		}
