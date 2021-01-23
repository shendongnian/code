          //Important note
          //Note the type of the image column. You want to give this column
      as a blob field to the crystal report.
          //therefore define the column type as System.Byte[]
          ImageTable.Columns.Add(new DataColumn("image",typeof(System.Byte[])));
          this.DsImages.Tables.Add(ImageTable);
