            int ky= 0;
            double attrib = CalculateWatermarkAttribute(i, j, out ky);
            DataRow dataRow = dataSet.Tables["Watermark_Books"].NewRow();
            DataRow tmpRow = dataSet.Tables["Books"].Select("id=" + ky)[0];
            foreach (System.Data.DataColumn column in dataSet.Tables["Watermark_Books"].Columns)
            {
                if (column.ColumnName == "WatermarkColumn")
                    dataRow["WatermarkColumn"] = attrib;
                else
                    dataRow[column.ColumnName] = tmpRow[column.ColumnName];
            }
