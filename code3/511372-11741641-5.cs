    if (dt.Rows.Count > 0)
         {
            foreach(DataRow row in dt.Rows)
             {
              string path="x:\\folder\\" + row[0] + ".png";
              byte []bytes=(byte[])row[1];
              System.IO.File.WriteAllBytes(path,bytes);
             }
         }
