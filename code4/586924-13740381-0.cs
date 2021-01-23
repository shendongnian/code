            private int scroll { get; set; }
    
            private void label1_Click(object sender, EventArgs e)
            {
            string strString = "This is scrollable text...This is scrollable text...This is scrollable text";
            scroll = scroll + 1;
            int iLmt = strString.Length - scroll;
            if (iLmt < 20)
            {
                scroll = 0;
            }
            string str = strString.Substring(scroll, 20);
            label1.Text = str;
        }
