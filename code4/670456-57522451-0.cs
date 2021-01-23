var ignoreQuantity = true;
using (var myStream = saveFileDialog1.OpenFile())
{
    using (var writer = new CsvWriter(new StreamWriter(myStream)))
    {
		var classMap = new DefaultClassMap<DataView>();
		classMap.AutoMap();
        classMap.Map(m => m.ResultQuantity).Ignore(ignoreQuantity)
		writer.Configuration.RegisterClassMap(classMap);
        writer.Configuration.Delimiter = "\t";
        writer.WriteHeader(typeof(DataView));
        _researchResults.ForEach(writer.WriteRecord);
    }
}
