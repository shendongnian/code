    protected override void SaveChanges()
    {
        using(SaveGame sg = new SaveGame())
        {
            sg.StartPosition = FormStartPosition.CenterScreen;
            DialogResult result = sg.ShowDialog();
            if(result == DialogResult.OK)
            {
                saveButton_Click(null, null);
            }
        }
    }
