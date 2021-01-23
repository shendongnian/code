	public static void AddImportData(CustomType ModelData)
	{
		FormattedType data = ConvertModelDataToFormattedData(ModelData);
		using (var db = new ImportFileContext())
		{
			dynamic temp = ModelData;
			ImportData(ModelData, data, db);
		}
	}
	private static void ImportData(CustomType modelData, FormattedType data, ImportFileContext db)
	{
		db.ImportFormattedData.Add(data);
		db.SaveChanges();
	}
	private static void ImportData(CustomType1 modelData, FormattedType data, ImportFileContext db)
	{
		db.ImportCsvData.Add(data);
		db.SaveChanges();
	}
	private static void ImportData(CustomType1 modelData, FormattedType data, ImportFileContext db)
	{
		db.ImportTabDelimetedData.Add(data);
		db.SaveChanges();
	}
