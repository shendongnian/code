    private void GetData()
	{
		// Start the retrieval of data on another thread to let the UI thread free
		ThreadPool.QueueUserWorkItem(o =>
		{
			// Empty the dataset so that there is only
			// one batch of data displayed.
			dataToWatch.Clear();
			// Make sure the command object does not already have
			// a notification object associated with it.
			command.Notification = null;
			// Create and bind the SqlDependency object
			// to the command object.
			SqlDependency dependency = new SqlDependency(command);
			dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
			using (SqlDataAdapter adapter = new SqlDataAdapter(command))
			{
				adapter.Fill(dataToWatch, tableName);
				// Update the UI
				dgv.Invoke(() =>
					{
					    dgv.DataSource = dataToWatch;
					    dgv.DataMember = tableName;
					    dgv.FirstDisplayedScrollingRowIndex = dgv.Rows.Count - 1;
					});
			}
		});
	}
