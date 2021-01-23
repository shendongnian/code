    foreach (XElement nod in resultElements.Elements(@"studentPunishmentsTable"))
     {
                  listb.Items.Add(penalty+Environment.NewLine+ issueDate + semesterDesc);
                    Grid.SetColumn(listb, colum);
                    Grid.SetRow(listb, row); row = row + 1;
    }
