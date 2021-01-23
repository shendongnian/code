    //Code in Button_Click
    {   
        foreach(DataGridVewRow dgvr in dgvProductCorrections.Rows)
        {
            Decimal fCorrection;
            //Check if value exists and it can be used. Add own other checks
            if(dgvr.Cells(this. dgvProductCorrection_Correction.Name).Value != null &&  Decimal.TryParse(dgvr.Cells(this.dgvProductCorrection_Correction.Name).Value.ToString(), fCorrection) = True)
            {
             //Here you can put a update code, or save a correction in list and then update all by one update call
            }
        }
    }
