        Random rW = new Random();
        foreach (TextBox textBox in addTextBox())
        {
            textBox.Visible = false;
        }
        RW = rW.Next(1, 4);
        while(usedWords.Contains(RW))
    {
        RW = rW.Next(1,4);
    }
    usedWords.Add(RW);
        if (RW == 1) //Cat
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
        }
        else if (RW == 2) //Elephant
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
        }
        else if (RW == 3) //Giraffe
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
        }
        else if (RW == 4) //Monkey
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
        }
        else
        {
        }
    }
