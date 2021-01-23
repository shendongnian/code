    public void btn_saveseats_Click(object sender, EventArgs e){
        String date = timepicker.Value.ToString("dd-mm-yyyy");
        String fileName = String.Format("{0}File.txt", date);
        using (StreamWriter writer = new StreamWriter(fileName)){
            writer.WriteLine(date);
            if(cbseat1.Checked)
                writer.WriteLine(cbseat1.Text);
            if(cbseat2.Checked)
                writer.WriteLine(cbseat2.Text);
            if(cbseat3.Checked)
                writer.WriteLine(cbseat3.Text);
            if(cbseat4.Checked)
                writer.WriteLine(cbseat4.Text);
            if(cbseat5.Checked)
                writer.WriteLine(cbseat5.Text);
            if(cbseat6.Checked)
                writer.WriteLine(cbseat6.Text);
            if(cbseat7.Checked)
                writer.WriteLine(cbseat7.Text);
            if(cbseat8.Checked)
                writer.WriteLine(cbseat8.Text);
            if(cbseat9.Checked)
                writer.WriteLine(cbseat9.Text);
            if(cbseat10.Checked)
                writer.WriteLine(cbseat10.Text);
            if(cbseat11.Checked)
                writer.WriteLine(cbseat11.Text);
            if(cbseat12.Checked)
                writer.WriteLine(cbseat12.Text);
        }
        MessageBox.Show("saved");
    }
