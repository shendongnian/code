    RunningResult[parameter.Uid] = (from source_row in RunningResult[parameter.Uid]
                                    join target_row in ColumnDataIndex[dest_key]
                                    on GetColumnFromUID(source_row, rel.SourceColumn) equals
                                        GetColumnFromUID(target_row, rel.TargetColumn)
                                    select new Row()
                                    {
                                        Columns = MergeColumns(source_row.Columns, target_row.Columns)
                                    }).ToList();
