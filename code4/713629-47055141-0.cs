    private static void findTableinRtf(string rtf)
        {
            var flowDocument = new FlowDocument();
            var textRange = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(rtf)))
            {
                textRange.Load(ms, DataFormats.Rtf);
            }
            var blocks = flowDocument.Blocks;
            foreach (var block in flowDocument.Blocks)
            {
                switch (block)
                {
                    case List list:
                         //implement List;
                        break;
                    case Table table:
                        workWithTable(table);
                        break;
                    case Paragraph paragraph:
                        convertParagraph(paragraph);
                        break;
                    case Section section:
                        convertSection(section);
                        break;
                    
                }
            }
            
        }
        private static void workWithTable(Table rtfTable)
        {
            TableColumnCollection columns = rtfTable.Columns;
            TableRowGroupCollection rowGroups = rtfTable.RowGroups;
            foreach (var row in rowGroups[0].Rows)
            {
                //access cells
                // row row.Cells[i];
            }
        }
