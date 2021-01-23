    public string isHighorlow(int number)
    {    
        if (number >=50)
        { 
             return "High";
        }
        else
        {
             return "Low";
        }
    }
    numbers info = new numbers();
    private void Btn_Click(object sender, EventArgs e)
    { 
      Messagebox.Show(info.isHighorlow(Convert.ToInt32(numberBOX.Text)))
    }
