     int sum = 0;
            panel1.Controls.OfType<UserControl>().ToList().ForEach(
                x =>
                {
                    TextBox ctl = x.Controls.OfType<TextBox>().Where(y => y.Name == "textbox2").FirstOrDefault();
                    sum += (ctl == null ? 0 : (!String.IsNullOrEmpty(ctl.Text.Trim()) ? Convert.ToInt32(ctl.Text.Trim()) : 0));
                }
                );
