    private void rbnbtnPageSetup_Click(object sender, EventArgs e)
    {
        if (IsFormOpen(typeof(GUI.Printing)))
        {
             var frm = Application.OpenForms.OfType<Form>().FirstOrDefault(x => x.GetType() == typeof(GUI.Printing)); //this retrieves the preview form
             frm.Show();
             frm.Preview();
        }
        else
        {
            MessageBox.Show("Please Open Printing Form");
        }
    }
