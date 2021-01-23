    private void CreateTxtArr()
    {
         txts = new TextBox[8];
         for (int i = 0; i < pnlTxt.Controls.Count; i++)
             if( pnlTxt.Controls[i] is TextBox)
                   txts[i] = (TextBox)pnlTxt.Controls[i];
    }
