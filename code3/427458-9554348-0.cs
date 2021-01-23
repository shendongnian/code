    using(DbClassesDataContext myDb = new DbClassesDataContext(dbPath)){
        PatientInfo patientInfo = new PatientInfo();
        patientInfo.Phy_ID = physcianID;
        patientInfo.Pat_First_Name = txtFirstName.Text;
        patientInfo.Pat_Middle_Name = txtMiddleName.Text;
        patientInfo.Pat_Last_Name = txtLastName.Text;
        patientInfo.Pat_Gender = cmbGender.Text;
        patientInfo.Pat_Marital_Status = cmbMaritalStatus.Text;
        patientInfo.Pat_Date_Of_Birth = dtpDOB.Value;
        patientInfo.Pat_Home_Add = txtHomeAdd.Text;
        patientInfo.Pat_Home_Num = txtPhone.Text;
        patientInfo.Pat_Work_Add = txtWorkAdd.Text;
        patientInfo.Pat_Work_Num = txtWorkPhone.Text;
        patientInfo.Pat_Prim_Physician = txtPrimPhysician.Text;
        patientInfo.Pat_Ref_Physician = txtRefePhysician.Text;
        //store to db
        myDb.Patients.AddObject(patientInfo);
        myDb.SaveChanges();
        return patientInfo;
    }
