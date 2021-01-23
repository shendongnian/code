    if (FU_CV.FileBytes.Length > 4194304)
    {
        modalpopup.Show();
    }
    else
    {
        int dept;
        if  (int.TryParse(DDL_Dept.SelectedValue, out dept))
            app.AddApplicant(txt_Mname.Text, dept);
        else 
            app.AddApplicant(txt_Mname.Text, null); //or whatever there should be for you
    }
