    private void btn_informationService_Click(object sender, EventArgs e)
    {
        panel_startMenu.Hide();
        panel_customerManagement.Hide();
        panel_informationService.Show();
    }
    
    private void btn_customerManagement_Click(object sender, EventArgs e)
    {
        panel_startMenu.Hide();
        panel_informationService.Hide();
        panel_customerManagement.Show();
    }
