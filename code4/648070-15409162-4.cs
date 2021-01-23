                  foreach (var column in dt[i].Columns)
                  {
                      xInnerElt[j].Add(
                          new XAttribute(
                              (column as DataColumn).ColumnName,
                              dt[i].Rows[j][(column as DataColumn)].ToString()
                          )
                      );
                  }
