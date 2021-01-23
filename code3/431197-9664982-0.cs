    // Use the component in free mode.
    ComponentInfo.SetLicense("FREE-LIMITED-KEY");
    // Define DataTable with two columns: 'Name' and 'Surname', and fill it with some data.
    // You don't have to do this if you already have a DataTable instance.
    var dataTable = new DataTable("People")
    {
        Columns =
        {
            new DataColumn("Name", typeof(string)),
            new DataColumn("Surname", typeof(string))
        },
        Rows =
        {
            new object[] { "John", "Doe" },
            new object[] { "Fred", "Nurk" },
            new object[] { "Hans", "Meier" },
            new object[] { "Ivan", "Horvat" }
        }
    };
    // Create and save a template document. 
    // You don't have to do this if you already have a template document.
    // This code is only provided as a reference how template document should look like.
    var document = new DocumentModel();
    document.Sections.Add(
        new Section(document,
            new Table(document,
                new TableRow(document,
                    new TableCell(document,
                        new Paragraph(document, "Name")),
                    new TableCell(document,
                        new Paragraph(document, "Surname"))),
                new TableRow(document,
                    new TableCell(document,
                        new Paragraph(document,
                            new Field(document, FieldType.MergeField, "RangeStart:People"),
                            new Field(document, FieldType.MergeField, "Name"))),
                    new TableCell(document,
                        new Paragraph(document,
                            new Field(document, FieldType.MergeField, "Surname"),
                            new Field(document, FieldType.MergeField, "RangeEnd:People")))))));
    document.Save("TemplateDocument.docx", SaveOptions.DocxDefault);
    // Load a template document.
    document = DocumentModel.Load("TemplateDocument.docx", LoadOptions.DocxDefault);
    // Mail merge template document with DataTable.
    // Important: DataTable.TableName and RangeStart/RangeEnd merge field names must match.
    document.MailMerge.ExecuteRange(dataTable);
    // Save the mail merged document.
    document.Save("Document.docx", SaveOptions.DocxDefault);
