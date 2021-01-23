            // Create data source for DataGridView.
            var people = new DataTable()
            {
                Columns = 
                {
                    new DataColumn("Name", typeof(string)),
                    new DataColumn("Surname", typeof(string))
                },
                Rows =
                {
                    { "John", "Doe" },
                    { "Fred", "Nurk" },
                    { "Hans", "Meier" },
                    { "Ivan", "Horvat" }
                }
            };
            // Create DataGridView and show it to select rows.
            var dataGridView = new DataGridView()
            {
                DataSource = people,
                Dock = DockStyle.Fill
            };
            new Form() { Controls = { dataGridView } }.ShowDialog();
            // Get selected items which will be used as data source for mail merge.
            var selectedItems = dataGridView.SelectedRows.Cast<DataGridViewRow>().Select(dgvRow => dgvRow.DataBoundItem).ToArray();
            // Create template document which is usually created with MS Word application and loaded with GemBox.Document library.
            // This code just shows the structure of the template document.
            var doc = new DocumentModel();
            doc.Sections.Add(
                new Section(doc,
                    new Table(doc,
                        new TableRow(doc,
                            new TableCell(doc,
                                new Paragraph(doc,
                                    new Run(doc, "Name") { CharacterFormat = { Bold = true } })),
                            new TableCell(doc,
                                new Paragraph(doc,
                                    new Run(doc, "Surname") { CharacterFormat = { Bold = true } })))
                        {
                            RowFormat = { RepeatOnEachPage = true }
                        },
                        new TableRow(doc,
                            new TableCell(doc,
                                new Paragraph(doc,
                                    new Field(doc, FieldType.MergeField, "RangeStart:SelectedPeople"),
                                    new Field(doc, FieldType.MergeField, "Name"))),
                            new TableCell(doc,
                                new Paragraph(doc,
                                    new Field(doc, FieldType.MergeField, "Surname"),
                                    new Field(doc, FieldType.MergeField, "RangeEnd:SelectedPeople")))))
                    { 
                        TableFormat = { PreferredWidth = new TableWidth(100, TableWidthUnit.Percentage) } 
                    }));
            // Execute mail merge. All selected people will be imported into the document.
            doc.MailMerge.Execute(selectedItems, "SelectedPeople");
            // Save document in DOCX and PDF formats.
            doc.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SelectedPeople.docx"));
            doc.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SelectedPeople.pdf"));
