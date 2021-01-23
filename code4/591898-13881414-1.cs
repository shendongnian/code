    private void button1_Click(object sender, EventArgs e)
        {
            foreach (var row in tableLayoutPanel1.Controls)
            {
                var panel = row as Panel;
                if (panel == null) continue;
                var checkedButton = 
                    panel.Controls.OfType<RadioButton>()
                        .FirstOrDefault(r => r.Checked);
                if (checkedButton == null) continue;
                //Process your radiobutton here.
            }
        }
