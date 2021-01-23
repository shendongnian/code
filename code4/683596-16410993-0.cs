    private void clicksave(object sender, EventArgs e)
    {
        string[] values = new string[6];
        values[0] = tbname.Text;
        values[1] = tbheight.Text;
        values[2] = tb40.Text;
        values[3] = tbposition.Text;
        values[4] = tbreps.Text;
        values[5] = tbverticle.Text;
        fileWriter.WriteLine(String.Join(",",values));
        fileWriter.Flush();
        fileWriter.Close();
        //}                   
    }
