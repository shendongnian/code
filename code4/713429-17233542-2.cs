    private void btnShowForDateRange_Click(object sender, EventArgs e)
    {
        tblDateRange = new DataTable();
        this.btnShowForDateRange.Enabled = false;
        this.btnFindVRM.Enabled = false;
        this.progressBar1.Visible = true;
        btnExport.Enabled = false;
        cboMachines.Items.Insert(0, "-ALL MACHINES-");
        cboMachines.SelectedIndex = 0;
        string[] parameters = { dtStartDate.Value.ToString("yyyy-MM-dd"), dtEndDate.Value.ToString("yyyy-MM-dd"), this.cboMachineGroup.Text, this.cboMachines.Text  };
        this.backgroundWorker1.RunWorkerAsync(parameters);
    }
