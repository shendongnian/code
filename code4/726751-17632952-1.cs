        if (CheckFiledIsEmpty() && CompetitorAlreadyExist())
            {
                string Column1 = textStN.Text;
                string Column2 = textN.Text;
                string Column3 = textSN.Text;
                string Column4 = textC.Text;
                string Column5 = textYB.Text;                    
                string[] row = { Column1, Column2, Column3, Column4, Column5 };
                dataGridView1.Rows.Add(row);
                textStN.Text = "";
                textN.Text = "";
                textSN.Text = "";
                textC.Text = "";
                textYB.Text = "";
             }
            else
            {
                MessageBox.Show("Input all information about competitor!");
            }
    }
