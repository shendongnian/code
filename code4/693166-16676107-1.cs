    		public IList Children
		{
			get
			{
				return new CompositeCollection()
            {
                new CollectionContainer() { Collection = Folders },
                new CollectionContainer() { Collection = Files }
            };
			}
		}
                    <HierarchicalDataTemplate DataType="{x:Type local:Folder}" ItemsSource="{Binding Children}">
