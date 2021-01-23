            DateTime? PartA_Date;
            DateTime dateOut2;
            if (!DateTime.TryParse(txt_PartA_Date.Text, out dateOut2))
            {
                lbl_message.Text += " * 'Date' is not a valid date!<br/>"; txt_PartA_Date.BackColor =
                    Color.FromName(ConfigurationManager.AppSettings["ErrorColour"]);
            }
            else
            {
                PartA_Date = dateOut2;
            }
