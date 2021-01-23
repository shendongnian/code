        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            object entity;
            ICustomTypeDescriptor rowDescriptor = Row as ICustomTypeDescriptor;
            if (rowDescriptor != null)
            {
                // Get the real entity from the wrapper
                entity = rowDescriptor.GetPropertyOwner(null);
            }
            else
            {
                entity = Row;
            }
            // Get the collection and make sure it's loaded
            RelatedEnd entityCollection = Column.EntityTypeProperty.GetValue(entity, null) as RelatedEnd;
            if (entityCollection == null)
            {
                throw new InvalidOperationException(String.Format("The Children template does not support the collection type of the '{0}' column on the '{1}' table.", Column.Name, Table.Name));
            }
            if (!entityCollection.IsLoaded)
            {
                entityCollection.Load();
            }
            int count = 0;
            var enumerator = entityCollection.GetEnumerator();
            while (enumerator.MoveNext())
                count++;
            HyperLink1.Text += " (" + count + ")";
        }
