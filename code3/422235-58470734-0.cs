    void Calculate_Total()
    {
    double txt1 = Convert.ToDouble(txtBox1.Text);
    double txt2 = Convert.ToDouble(txtBox2.Text);
    double txt3 = Convert.ToDouble(txtBox3.Text);
    double txt4 = Convert.ToDouble(txtBox4.Text);
    double txt5 = Convert.ToDouble(txtBox5.Text);
    double txt6 = Convert.ToDouble(txtBox6.Text);
    double txt7 = Convert.ToDouble(txtBox7.Text);
    double txt8 = Convert.ToDouble(txtBox8.Text);
    
    double total = txt1 + txt2 + txt3 + txt4 + txt5 + txt6 + txt7 + txt8;
    Label1.Text = Convert.Tostring(total);
    }
