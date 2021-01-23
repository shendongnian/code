    private void txtnapsaserach_TextChanged(object sender, EventArgs e)
    {
         float value;
         if (!float.TryParse(txtnapsaserach.Text, out value))
             return;
    
         if (value > 0)
         {
            var napsatabs = napsaTableBindingSource.List as List<NapsaTable>;
            napsaTableBindingSource.DataSource = 
                napsatabs.Where(p =>p.NapsaRate == value).ToList();
         }
    }
