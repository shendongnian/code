	internal int Find(PropertyDescriptor property, object key, bool keepIndex)
    {
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		if (((property != null) && (this.list is IBindingList)) && ((IBindingList) this.list).SupportsSearching)
		{
			return ((IBindingList) this.list).Find(property, key);
		}
		if (property != null)
		{
			for (int i = 0; i < this.list.Count; i++)
			{
				object obj2 = property.GetValue(this.list[i]);
				if (key.Equals(obj2))
				{
					return i;
				}
			}
		}
		return -1;
	}
	
