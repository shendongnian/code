    private void btn_delete_Click(object sender, EventArgs e)
    {
        Delete();
    }
    private void btn_Ophalen_Click(object sender, EventArgs e)
    {
        Open();
    }
    
    private void Delete()
    {
        if (dialogResult == DialogResult.Yes)
        {
            if (objBestand.bestandsnaamString == file2)
            {
                objBestand.VerwijderBestand();
                Open();
            }
        }
    }
    private void Open()
    {
        string PathString;  //  maak string aan 
            PathString = textBox1.Text + @":\" + textBox2.Text; //vul_list string mwet waarde
            objBestanden = new clsBestanden();
            objBestanden.Zoekbestanden(PathString);  // Roep method Zoekbestanden aan 
            vul_list();  // vul lijst of form
    }
