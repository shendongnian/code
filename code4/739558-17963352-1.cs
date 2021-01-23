        SubForm objForm= SubForm.InstanceForm();
        objForm.TopLevel = false;
        pnlSubSystem.Controls.Add(objForm);
        objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        objForm.Dock = DockStyle.Fill;
        objForm.Show();
