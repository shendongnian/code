    void FillLookUp() {
        lookUpEdit1.Properties.DataSource = new List<StepDetails>{
            new StepDetails(){ StepID = 0, Description = "Step1" },
            new StepDetails(){ StepID = 1, Description = "Step2" },
            new StepDetails(){ StepID = 2, Description = "Step3" },
        };
        lookUpEdit1.Properties.DisplayMember = "Description";
        lookUpEdit1.Properties.ValueMember = "StepID";
        lookUpEdit1.Properties.Columns.Clear();
        lookUpEdit1.Properties.Columns.Add(new LookUpColumnInfo("Description", "Step Detail"));
    }
