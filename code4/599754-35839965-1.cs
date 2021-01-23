            try
            {
                cb.Tag = 0;
                cb.DataSource =null;
                cb.Items.Clear();
                
                DataSet ds = DataMgr.GetDsBySql(sql);
                if (!DataUtils.HasDtWithRecNoErr(ds))
                {                    
                    cb.Text = "No data";
                }
                else
                {
                    cb.DataSource = ds.Tables[0];
                    cb.DisplayMember = displayfld;
                    cb.ValueMember = keyfld;
                }
                cb.Tag = cb.Items.Count;
            }
            catch (Exception ex)
            {
                Int32 len = ex.Message.Length > 200 ? 200 : ex.Message.Length;
                cb.Text = ex.Message.Substring(0, len);
            }                
        }
