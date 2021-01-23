    for (int i = 0; i < 7; i++)
    {
        if (checkBoxes[i].Checked == false)
        {
            labels[i].Text = rng.Next(1, 7).ToString();
        }
    }
