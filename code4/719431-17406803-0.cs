    public void btn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            DataGridForm window = new DataGridForm(DaysList[int.Parse(button.Tag.ToString())].Elements);
            window.Show();
        }
