    protected void buttonSaveSession_Click(object sender, EventArgs e)
    {
        string patientName = textBoxPatientName.Text;
        Session["PatientName"] = patientName;
    }
