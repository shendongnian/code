     public void addPatientInformation() {
        using(DbClassesDataContext myDb = new DbClassesDataContext()) {
            myDb.PatientInfos.InsertOnSubmit(new PatientInfo {
                Phy_ID = physcianID,
                Pat_First_Name = txtFirstName.Text,
                Pat_Middle_Init = txtMiddleName.Text,
                Pat_Last_Name = txtLastName.Text,
                Pat_Gender = cmbGender.Text,
                Pat_Marital_Status = cmbMaritalStatus.Text,
                Pat_Date_Of_Birth = dtpDOB.Value,
                Pat_Home_Add = txtHomeAdd.Text,
                Pat_Home_Num = txtPhone.Text,
                Pat_Work_Add = txtWorkAdd.Text,
                Pat_Work_Num = txtWorkPhone.Text,
                Pat_Prim_Physician = txtPrimPhysician.Text,
                Pat_Ref_Physician = txtRefePhysician.Text,
            });
            myDb.SubmitChanges();
        }
    }
