    String GetRadioButtonValue() {
             if( radioButton1.Checked ) return radioButton1.Text;
        else if( radioButton2.Checked ) return radioButton2.Text;
        else                            return radioButton3.Text;
    }
