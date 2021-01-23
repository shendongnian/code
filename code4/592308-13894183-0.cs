    private void _x_y_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            // use the Name of the textbox to determine x, y value
            string[] tmp_x_y = tb.Name.Split("_");
            // you may have to adjust these indices based on how Split actually
            // does its work.
            int x = int.Parse(tmp_x_y[0]);
            int y = int.Parse(tmp_x_y[1]);
            int number = int.Parse(tb.Text);
            if ((number >= 1) && (number <= 9))
            {
                for (int i = 0; i <= 8; i++)
                {
                    if (i == (number - 1))
                    {
                        content[x, y, i] = true;
                    }
                    else
                    {
                        content[x, y, i] = false;
                    }
                }
            }
        }
