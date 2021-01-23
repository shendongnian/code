        /// <summary>
        /// Gets the columns collection.
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public GridColumnCollection Columns
        {
            get
            {
                if (columnsCollection == null)
                {
                    if (columnsArrayList == null)
                    {
                        this.EnsureChildControls();
                        if (columnsArrayList == null)
                            columnsArrayList = new ArrayList();
                    }
                    columnsCollection = new GridColumnCollection(columnsArrayList);
                }
                return columnsCollection;
            }
        }
