    public void textBox_Validating()
    {
        Regex reg = new Regex("^([0-9]{1,3}\.){3}[0-9]{1,3}$");
        bool valide = reg.IsMatch(textBox.Text);
        //do whatever you want if it is not an ip (valide == false)
    }
