		private void CheckType(object o)
		{
			if (o is IDictionary)
			{
				Debug.WriteLine("I implement IDictionary");
			}
			else if (o is IList)
			{
				Debug.WriteLine("I implement IList");
			}
		}
