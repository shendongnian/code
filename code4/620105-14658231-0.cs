            // Programmatically wire up all Changed events to enable the button
            foreach (Control ctl in this.Controls)
            {
                if (ctl is CheckBox)
                {
                    ((CheckBox)ctl).CheckedChanged += new EventHandler(Button_Enable);
                }
                else if (ctl is RadioButton)
                {
                    ((RadioButton)ctl).CheckedChanged += new EventHandler(Button_Enable);
                }
                // Here, wire up all other control types you'd like the button to respond to
            }
