    BindingList<PatientInfo> data = new BindingList<PatientInfo>();
    dgvMyPatients.DataSource = data;
    ...
    public void fillDataGrid(IQueryable<PatientInfo> patients)
    {
        data.Clear();
        data.AddRange(patients);
    }
