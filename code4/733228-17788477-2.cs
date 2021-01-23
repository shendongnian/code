    // this field used to avoid loading data which you already have
    private Person currentPerson;
    void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            HidePersonDetails();
            return;
        }
        DataGridView grid = (DataGridView)sender;
        var person = grid.Rows[e.RowIndex].DataBoundItem as Person;
        if (person == null)
        {
            HidePersonDetails();
            return;
        }
        var rectangle = grid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
        var cellLocation = rectangle.Location;
        var detailsLocation = new Point(e.X + cellLocation.X, 
                                        e.Y + cellLocation.Y + rectangle.Height);
        ShowPersonDetails(person, detailsLocation);
    }
    private void dataGridView1_MouseLeave(object sender, EventArgs e)
    {
        HidePersonDetails();
    }
    private void ShowPersonDetails(Person person, Point location)
    {
        if (currentPerson != person)
        {
            // get data from SQL server
            // set datasource of your details grid
            currentPerson = person;
        }
        label1.Text = person.Name;
        label1.Location = location;
        label1.Show();
    }
    private void HidePersonDetails()
    {
        label1.Hide();
    }
