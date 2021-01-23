    sheet.AutoFilter.Sort.SortFields.Add(oRange, XlSortOrder.xlAscending);</s>
       <s> // add the excel table entity with EPPLUS (available on Nuget)
    var table = ws.Tables.Add(range, "table1");
    table.TableStyle = OfficeOpenXml.Table.TableStyles.Light2;
       
