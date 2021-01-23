    public class CustomType1 : CustomType
    {
        public override void FormatAndWriteToDB(DataBase db)
        {
            FormattedType data = ConvertModelDataToFormattedData(ModelData);
            db.ImportCsvData.Add(data);
        }
    }
