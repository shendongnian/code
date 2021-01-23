     //part of btn_delete_click event code
     if (dialogResult == DialogResult.Yes)
      {
          if (objBestand.bestandsnaamString == file2)
          {
              objBestand.VerwijderBestand();
              
              Ophalen();
          }
      }
    
    private void btn_Ophalen_Click(object sender, EventArgs e)
    {
        Ophalen();
    }
    
    private void Ophalen()
    {
        string PathString;  //  maak string aan
        PathString = textBox1.Text + @":\" + textBox2.Text; //vul_list string mwet waarde
        objBestanden = new clsBestanden();
        objBestanden.Zoekbestanden(PathString);  // Roep method Zoekbestanden aan 
        vul_list();  // vul lijst of form
    }
