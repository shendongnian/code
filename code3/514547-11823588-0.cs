    private void btn_edit_Click(object sender, EventArgs e)
    {
        bufferedListView1.Items.Clear();
        string fileContents = File.ReadAllText("C:\\sample.txt");
        string replacedContents = fileContenxt.Replace(pname + "@" + pno, 
            txt_editname.Text + "@" + txt_editno.Text);
        File.WriteAllText("C:\\sample.txt", replacedContents);
        // Rest of code
    }
