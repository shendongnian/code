    if (wsPart.Worksheet.Elements<MergeCells>().Count() > 0)
                {
                    MergeCells mergeCells = wsPart.Worksheet.Elements<MergeCells>().First();
                    foreach (MergeCell mergeCell in mergeCells)
                    {
                       // mergeCell.
                    }
                }
