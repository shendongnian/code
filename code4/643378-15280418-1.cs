    private void xrTableCell40_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string value;
            bool Isnum;
            double holder;
            string zero;
            value = xrTableCell38.ToString();
            zero = 0.ToString(); 
            Isnum = double.TryParse(value, out holder);
                if(Isnum != true)
                {
                  xrTableCell40.Text = zero;
                }
                else if (holder > 0)
                {
                  holder = Convert.ToDouble(xrLabel135.Summary.GetResult()) / Convert.ToDouble(xrTableCell38.Summary.GetResult());
                  string s = string.Format("{0:N2}", holder);
                  xrTableCell40.Text = Convert.ToString(s);
                }
                else
                {
                  xrTableCell40.Text = zero;
                } 
      }
