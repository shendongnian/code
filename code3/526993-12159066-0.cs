    private void getImage()
        {
            FileStream fs;
            fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "img\\cube.png", FileMode.Open);
            BinaryReader BinRed = new BinaryReader(fs);
            try
            {
                CreateTable();
                DataRow dr = this.DsImages.Tables["images"].NewRow();
                dr["image"] = BinRed.ReadBytes((int)BinRed.BaseStream.Length);
                this.DsImages.Tables["images"].Rows.Add(dr);
                //FilStr.Close();
                BinRed.Close();
                DynamicImageExample DyImg = new DynamicImageExample();
                DyImg.SetDataSource(this.DsImages);
                this.crystalReportViewer1.ReportSource = DyImg;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Error");
            }
