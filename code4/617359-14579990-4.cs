    var customBuilder = new RowsBuilder<CustomClassification>(
                            t => new ExcelRow(ExcelCell.Map(t.ChemicalAbstractService),
                                              ExcelCell.Map(t.Substance), 
                                              ExcelCell.Map(t.Columns("Classifidcation")),
                                              ExcelCell.Map(t.Columns("Classification"))));
    var builders = new List<IRowsBuilder>();
    builder.Add(customBuilder);
    builder.Add(someOtherBuilder);
    var excelFormatter = new ExcelMediaTypeFormatter(builders, format => "excel");
    GlobalConfiguration.Configuration
                       .Formatters
                       .Add(excelFormatter);
