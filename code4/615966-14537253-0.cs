            foreach (Control control in Controls)
            {
                Button button = control as Button;
                if (button == null) continue;
                switch (button.Name)
                {
                    case "button1":
                        button.BackColor = Color.Red;
                        break;
                    case "button2":
                        button.BackColor = Color.Yellow;
                        break;
                    case "button3":
                        button.BackColor = Color.Green;
                        break;
                    default:
                        button.BackColor = Color.Black;
                        break;
                }
            }
