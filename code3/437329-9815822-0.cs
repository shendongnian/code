		private void MyCommonMethod()
		{
			lock (this.lockObject)
			{
				var element = XElement.Load(path);
				// some operations
				element.save(path);
			}
		}
