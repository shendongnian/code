    private void richTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBox2.Items.Add(richTextBox2.Text);
                
            
                
                    if (richTextBox2.Text == a1)
                    {
                        MessageBox.Show("-c can't be used as a raw command, it is used to define when another command is being used. Try -c r to run the game...");
                    }
                    else if (richTextBox2.Text == a2)
                    {
                        System.Diagnostics.Process.Start("Arcanists.jar");
                    }
                    else if (richTextBox2.Text == a3)
                    {
                        foreach (System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
                        {
                            if (myProc.ProcessName == "javaw")
                            {
                                myProc.Kill();
                            }
                        }
                    }
                    else if (richTextBox2.Text == a4)
                    {
                        MessageBox.Show("Type -c r to run the game");
                    }
                    else
                    {
                        listBox2.Items.Add("*!Invalid Command!*");
                    }
            }
        }
