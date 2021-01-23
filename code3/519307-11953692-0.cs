     GridViewColumn column = new GridViewColumn();
                                column.Header = key;
                                column.Width = 130;                     
                                FrameworkElementFactory controlFactory = new FrameworkElementFactory(typeof(TextBlock));
                                var itemsBinding = new System.Windows.Data.Binding("Values")
                                {
                                    Converter = new LoadProfileConverter(),
                                    ConverterParameter = key
                                    
                                };                           
                               
                                column.DisplayMemberBinding = itemsBinding;
                                LoadProfileGrid.Columns.Add(column);
