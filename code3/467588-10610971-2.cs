    private void Sheet1_Startup(object sender, System.EventArgs e)
            {
                Globals.Sheet1.Names.Add("test", Globals.Sheet1.Range["A1"], System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing);
                MessageBox.Show(Globals.Sheet1.Range["test"].Address);
                Globals.Sheet1.Names.Add("test", Globals.Sheet1.Range["A2"], System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing);
                MessageBox.Show(Globals.Sheet1.Range["test"].Address);
            }
