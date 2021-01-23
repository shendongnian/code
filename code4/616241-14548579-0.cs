       private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            var cn = textBox2.Text.Where(c => char.IsLetter(c)).Count();
            var cd = textBox2.Text.Where(c => char.IsNumber(c)).Count();
            if (cn >= 2 && cd >= 2)
            {
                //Success, Do Stuff
            }
            else
            {
                e.Cancel = true;
            }
        }
