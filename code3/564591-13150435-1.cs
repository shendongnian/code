    void OnButtonClick(object sender, EventArgs e)
            {
                int buttonIndex = Array.IndexOf(buttons, sender);
                for (int index = 0; index < buttons.Length; index++)
                {
                    if (index <= buttonIndex)
                    {
                        buttons[index].Enabled = buttons[index].Visible = false;
                    }
                    else
                    {
                        buttons[index].Enabled = buttons[index].Visible = true;
                    }
                }
            }
