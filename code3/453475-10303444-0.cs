    private void addEditCoalSeams(bool isAdd)
        {
            int? myId=null;
            if (!isAdd)
            {
                myId = (int?)coalSeamsComboBox.SelectedValue;
            }
    
            using (CoalSeamsForm csf = new CoalSeamsForm(myId, isAdd))
            {
                if (DialogResult.OK == csf.ShowDialog())
                {
                    coalSeamsTableAdapter.Fill(well_Information2DataSet.CoalSeams);
                    coalSeamsComboBox.SelectedValue = csf.coalID;
                }
            }
        }
