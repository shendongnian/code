    private void ucPerson_Load(object sender, EventArgs e)
    {
        person = new Person();
        BackgroundWorker backgroundBinder = new BackgroundWorker();
        backgroundBinder.DoWork += GetData;
        backgroundBinder.RunWorkerCompleted += BindComboBoxes;
        backgroundBinder.RunWorkerAsync();
    }
    
    <<yourReturnType>> source;
    
    private void GetData(object sender, DoWorkEventArgs e)
    {
        source = Program.eService.GetEducationLevels();
    }
    
    private void BindComboBoxes(object sender, RunWorkerCompletedEventArgs e)
    {
        cmbNationality.DisplayMember = "Name";
        cmbNationality.ValueMember = "NationalityID";
        cmbNationalty.DataSource = source;
    }
