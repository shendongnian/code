    foreach (DataRow row in dsGetAvailUsers.Tables[0].Rows)
	{
		var item = new Dokument();
		int i = 0;
		item.Label = new Hashtable();
		item.array = new Hashtable();
		foreach (DataColumn _col in dsGetAvailUsers.Tables[0].Columns) 
		{
			item.Label.Add(i, _col.ColumnName);
			item.array.Add(_col.ColumnName,row[i].ToString());
			++i;
		}
		listDokument.Add(item);
		RunOnUiThread (() => {DokumentAdapter.Add (item); });
	}
