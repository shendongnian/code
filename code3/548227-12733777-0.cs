	class RecordFileReader
	{
		void UpdateAll(file)
		{
			foreach (var record in file)
			{
				_fileRecordImporter.Import(record)
			}
		}
	}
	class FileRecordImporter
	{	
		void Import(record)
		{
			db_record = find if it is in db
			if (db_record != null)
			{
				_dbRecordUpdater.Update(db_record, record)
				return;
			}
			_dbRecordCreator.CreateFrom(record);
		}
	class DbRecordUpdater
	{
		void Update(db_record, record)
		{
			var recordUpdater = _recordUpdaters.FirstOrDefault(x=>x.IsMatch(db_record, record));
			if (recordUpdater != null)
			{
				recordUpdater.Update(db_record, record)
			}
		}
	}
	class DbRecordCreator
	{
		void CreateFrom(record)
		{
			var recordCreator = _recordCreators.FirstOrDefault(x=>x.IsMatch(record));
			if (recordCreator != null)
			{
				var db_record = recordCreator.Create(record)
				...
			}
		}
	}
