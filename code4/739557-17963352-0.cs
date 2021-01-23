        SubForm objForm= SubForm.InstanceForm();
        this.IsMdiContainer = true;
        objForm.TopLevel = false;
        pnlSubSystem.Controls.Add(objForm);
        objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        objForm.Dock = DockStyle.Fill;
        objForm.Show();
