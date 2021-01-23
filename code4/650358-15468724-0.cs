    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode )
        {
            case Keys.NumPad1:
                if (checkBox1.Checked)
                    checkBox1.Checked = false;
                else
                    checkBox1.Checked = true;
    
                break;
            case Keys.NumPad2:
                if (checkBox2.Checked)
                    checkBox2.Checked = false;
                else
                    checkBox2.Checked = true;
    
                break;
            case Keys.NumPad3:
                if (checkBox3.Checked)
                    checkBox3.Checked = false;
                else
                    checkBox3.Checked = true;
    
                break;
            case Keys.NumPad4:
                if (checkBox4.Checked)
                    checkBox4.Checked = false;
                else
                    checkBox4.Checked = true;
    
                break;
            case Keys.NumPad5:
                if (checkBox5.Checked)
                    checkBox5.Checked = false;
                else
                    checkBox5.Checked = true;
    
                break;
            case Keys.NumPad6:
                if (checkBox6.Checked)
                    checkBox6.Checked = false;
                else
                    checkBox6.Checked = true;
    
                break;
            case Keys.NumPad7:
                if (checkBox7.Checked)
                    checkBox7.Checked = false;
                else
                    checkBox7.Checked = true;
    
                break;
            case Keys.NumPad8:
                if (checkBox8.Checked)
                    checkBox8.Checked = false;
                else
                    checkBox8.Checked = true;
    
                break;
            case Keys.NumPad9:
                if (checkBox9.Checked)
                    checkBox9.Checked = false;
                else
                    checkBox9.Checked = true;
    
                break;
            default:
                break;
            }
        }
