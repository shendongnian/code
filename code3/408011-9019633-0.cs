    private void button10_Click_1(object sender, EventArgs e)
    {
       Int32 IsAnumber;
    if(Int32.TryParse(textBox23.Text, out IsAnumber)
    {
    if (IsAnumber > 9)
    {
        double L1 = double.Parse(textBox13.Text);
        double L2 = double.Parse(textBox16.Text);
        double wynik = L1 - L2;
        textBox23.Text = wynik.ToString();
        string str = null;
        string retString = null;
        str = textBox23.Text;
        retString = str.Substring(0, 1);
        textBox21.Text = retString;
        str = textBox23.Text;
        retString = str.Substring(1, 1);
        textBox22.Text = retString;
    }
    else 
    {
        double L1 = double.Parse(textBox13.Text);
        double L2 = double.Parse(textBox16.Text);
        double wynik = L1 - L2;
        textBox23.Text = wynik.ToString();
        string str = null;
        string retString = null;
        str = textBox23.Text;
        retString = str.Substring(0, 1);
        textBox21.Text = retString;
    }
    }
