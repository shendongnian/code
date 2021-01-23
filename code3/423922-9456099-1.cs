        private void FillData()
        {
            List<iddesc> DataList = new List<iddesc>();
            for (int i = 1; i < 11; i++)
            {
                DataList.Add(new iddesc() { id = i, description = "Desc" + i.ToString() });
            }
            ComboCol.ValueMember = "id";
            ComboCol.DisplayMember = "description";
            ComboCol.DataSource = DataList;
            for (int i = 0; i < 10; i++)
            {
                grd.Rows.Add();
                grd[ComboCol.Name, i].Value = DataList[i].id;//Here you deliver the valuemember
                grd[Column1.Name, i].Value = DataList[i].description;
            }
        }
