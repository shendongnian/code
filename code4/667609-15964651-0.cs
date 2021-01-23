    private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            groupBoxPenghuni.Visible = false;
            groupBoxStaff.Visible = false;
            groupBoxRoom.Visible = false;
            groupBoxDPenghuni.Visible = true;
            groupBoxPenghasilan.Visible = false;
            GroupBox_AddResident_Resident.Visible = false;
            GroupBox_AddResident_Room.Visible = false;
            GroupBox_AddResident1.Visible = false;
            GroupBox_DeleteResident_Resident.Visible = false;
            GroupBox_DeleteResident1.Visible = false;
            GroupBox_Resident.Visible = false;
            GroupBox_Update_Room.Visible = false;
            GroupBox_UpdateResident1.Visible = false;
        }
    }
