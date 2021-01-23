    private void button3_Click(object sender, EventArgs e)
    {
        //File.WriteAllText(txtnewtariff.Text, Regex.Replace(File.ReadAllText(txtcurrent.Text), "^(0|00){1,2}", "+", RegexOptions.Multiline));
        if (txtcurrent.Text.Trim().Length == 0)
        {
            MessageBox.Show("No Tariff Selected","Error On Conversion");
            return;
        }
        if (txtnewtariff.Text.Trim().Length == 0)
        {
            MessageBox.Show("Please Select a New Tariff File", "Error On Conversion");
            return;
        }
        if (txtctrycode.Text.Trim().Length == 0)
        {
            MessageBox.Show("Please enter an E164 Country Code", "Error On Conversion");
            return;
        }
       
        var lines = File.ReadAllLines(txtcurrent.Text).ToList();
        var regex = new Regex(@"^[00]{2}");
        var startFrom = lines.IndexOf("[Destinations]");
        //Start replacing from the index of "[Destinations]"
        for (int i = startFrom; i < lines.Count; i++)
        {
            //Assuming the ini section ends at an empty line - stop replacing
            if (lines[i].Trim() == string.Empty)
                break;
            lines[i] = regex.Replace(lines[i], "+");
        }
        File.WriteAllLines(txtnewtariff.Text, lines);
        var lines1 = File.ReadAllLines(txtcurrent.Text).ToList();
        var regex1 = new Regex(@"^[0]{1}");
        var startFrom1 = lines.IndexOf("[Destinations]");
        //Start replacing from the index of "[Destinations]"
        for (int i = startFrom1; i < lines.Count; i++)
        {
            //Assuming the ini section ends at an empty line - stop replacing
            if (lines1[i].Trim() == string.Empty)
                break;
            lines[i] = regex1.Replace(lines[i], "+" + txtctrycode.Text);
        }
        File.WriteAllLines(txtnewtariff.Text, lines);
        var lines2 = File.ReadAllLines(txtcurrent.Text).ToList();
        var regex2 = new Regex(@"^[1]");
        var startFrom2 = lines.IndexOf("[Destinations]");
        //Start replacing from the index of "[Destinations]"
        for (int i = startFrom2; i < lines.Count; i++)
        {
            //Assuming the ini section ends at an empty line - stop replacing
            if (lines2[i].Trim() == string.Empty)
                break;
            lines[i] = regex2.Replace(lines[i], "+" + txtctrycode.Text + "1");
        }
        File.WriteAllLines(txtnewtariff.Text, lines);
        File.WriteAllLines(txtnewtariff.Text, lines);
        var lines3 = File.ReadAllLines(txtcurrent.Text).ToList();
        var regex3 = new Regex(@"^[2]");
        var startFrom3 = lines.IndexOf("[Destinations]");
        //Start replacing from the index of "[Destinations]"
        for (int i = startFrom3; i < lines.Count; i++)
        {
            //Assuming the ini section ends at an empty line - stop replacing
            if (lines3[i].Trim() == string.Empty)
                break;
            lines[i] = regex3.Replace(lines[i], "+" + txtctrycode.Text + "2");
        }
        File.WriteAllLines(txtnewtariff.Text, lines);
        var lines4 = File.ReadAllLines(txtcurrent.Text).ToList();
        var regex4 = new Regex(@"^[3]");
        var startFrom4 = lines.IndexOf("[Destinations]");
        //Start replacing from the index of "[Destinations]"
        for (int i = startFrom4; i < lines.Count; i++)
        {
            //Assuming the ini section ends at an empty line - stop replacing
            if (lines4[i].Trim() == string.Empty)
                break;
            lines[i] = regex4.Replace(lines[i], "+" + txtctrycode.Text + "3");
        }
        File.WriteAllLines(txtnewtariff.Text, lines);
        var lines5 = File.ReadAllLines(txtcurrent.Text).ToList();
        var regex5 = new Regex(@"^[4]");
        var startFrom5 = lines.IndexOf("[Destinations]");
        //Start replacing from the index of "[Destinations]"
        for (int i = startFrom5; i < lines.Count; i++)
        {
            //Assuming the ini section ends at an empty line - stop replacing
            if (lines5[i].Trim() == string.Empty)
                break;
            lines[i] = regex5.Replace(lines[i], "+" + txtctrycode.Text + "4");
        }
        File.WriteAllLines(txtnewtariff.Text, lines);
        var lines6 = File.ReadAllLines(txtcurrent.Text).ToList();
        var regex6 = new Regex(@"^[5]");
        var startFrom6 = lines.IndexOf("[Destinations]");
        //Start replacing from the index of "[Destinations]"
        for (int i = startFrom6; i < lines.Count; i++)
        {
            //Assuming the ini section ends at an empty line - stop replacing
            if (lines6[i].Trim() == string.Empty)
                break;
            lines[i] = regex6.Replace(lines[i], "+" + txtctrycode.Text + "5");
        }
        File.WriteAllLines(txtnewtariff.Text, lines);
        var lines7 = File.ReadAllLines(txtcurrent.Text).ToList();
        var regex7 = new Regex(@"^[6]");
        var startFrom7 = lines.IndexOf("[Destinations]");
        //Start replacing from the index of "[Destinations]"
        for (int i = startFrom7; i < lines.Count; i++)
        {
            //Assuming the ini section ends at an empty line - stop replacing
            if (lines7[i].Trim() == string.Empty)
                break;
            lines[i] = regex7.Replace(lines[i], "+" + txtctrycode.Text + "6");
        }
        File.WriteAllLines(txtnewtariff.Text, lines);
        var lines8 = File.ReadAllLines(txtcurrent.Text).ToList();
        var regex8 = new Regex(@"^[7]");
        var startFrom8 = lines.IndexOf("[Destinations]");
        //Start replacing from the index of "[Destinations]"
        for (int i = startFrom8; i < lines.Count; i++)
        {
            //Assuming the ini section ends at an empty line - stop replacing
            if (lines8[i].Trim() == string.Empty)
                break;
            lines[i] = regex8.Replace(lines[i], "+" + txtctrycode.Text + "7");
        }
        File.WriteAllLines(txtnewtariff.Text, lines);
        var lines9 = File.ReadAllLines(txtcurrent.Text).ToList();
        var regex9 = new Regex(@"^[8]");
        var startFrom9 = lines.IndexOf("[Destinations]");
        //Start replacing from the index of "[Destinations]"
        for (int i = startFrom9; i < lines.Count; i++)
        {
            //Assuming the ini section ends at an empty line - stop replacing
            if (lines9[i].Trim() == string.Empty)
                break;
            lines[i] = regex9.Replace(lines[i], "+" + txtctrycode.Text + "8");
        }
        File.WriteAllLines(txtnewtariff.Text, lines);
        var lines10 = File.ReadAllLines(txtcurrent.Text).ToList();
        var regex10 = new Regex(@"^[9]");
        var startFrom10 = lines.IndexOf("[Destinations]");
        //Start replacing from the index of "[Destinations]"
        for (int i = startFrom10; i < lines.Count; i++)
        {
            //Assuming the ini section ends at an empty line - stop replacing
            if (lines10[i].Trim() == string.Empty)
                break;
            lines[i] = regex10.Replace(lines[i], "+" + txtctrycode.Text + "9");
        }
        File.WriteAllLines(txtnewtariff.Text, lines);
        MessageBox.Show(txtnewtariff.Text,
    "Conversion Complete");
