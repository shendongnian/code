		public object[,] ConvertListToObject<T>(IEnumerable<T> dataSource)
		{
			if (dataSource != null)
			{
				var rows = dataSource.Count();
				var propertyInfos = typeof (T).GetProperties(BindingFlags.Public);
				var cols = propertyInfos.Length;
				var excelarray = new object[rows,cols];
				var i = 0;
				foreach (var data in dataSource)
				{
					for (var j = 0; j < cols; j++)
					{
						excelarray[i, j] = propertyInfos[j].GetValue(data, null);
					}
					i++;
				}
				return excelarray;
			}
			return new object[,] {};
		}
