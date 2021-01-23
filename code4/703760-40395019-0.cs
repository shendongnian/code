    // Если таблица пустая, то привязываем ее к журналу 
            	if(dgEvents.ItemsSource == null)
            		dgEvents.ItemsSource = events.Entries;
            	// Обновляем записи
            	CollectionViewSource.GetDefaultView(dgEvents.ItemsSource).Refresh();
            	// Очищаем описание сортировки
            	dgEvents.Items.SortDescriptions.Clear();
			    // Созадем описание сортировки
            	dgEvents.Items.SortDescriptions.Add(new SortDescription(dgEvents.Columns[0].SortMemberPath, ListSortDirection.Descending));
            	
            	// Очищаем сортировку всех столбцов
            	foreach (var col in dgEvents.Columns)
    			{
        			col.SortDirection = null;
    			}
            	// Задаем сортировку времени по убыванию (последняя запись вверху)
            	dgEvents.Columns[0].SortDirection = ListSortDirection.Descending;
            	// Обновляем записи
            	dgEvents.Items.Refresh();
