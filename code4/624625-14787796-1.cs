          try
          {
                   //get the image file into a stream reader.
                   FileStream FilStr = new FileStream(this.openFileDialog1.FileName, FileMode.Open);
                    BinaryReader BinRed = new BinaryReader(FilStr);
                   //Adding the values to the columns
                   // adding the image path to the path column
                   DataRow dr = this.DsImages.Tables["images"].NewRow();
                   dr["path"] = this.openFileDialog1.FileName;
                   //Important:
                   // Here you use ReadBytes method to add a byte array of the image stream.
                   //so the image column will hold a byte array.
                   dr["image"] = BinRed.ReadBytes((int)BinRed.BaseStream.Length);
                   this.DsImages.Tables["images"].Rows.Add(dr);
                   FilStr.Close();
                   BinRed.Close();
                   //create the report object
                   DynamicImageExample DyImg = new DynamicImageExample();
                   // feed the dataset to the report.
                   DyImg.SetDataSource(this.DsImages);
                   this.crystalReportViewer1.ReportSource = DyImg;
          }
          catch(Exception er)
          {
                   MessageBox.Show(er.Message,"Error");
          }
