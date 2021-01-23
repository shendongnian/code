            foreach(Control item in Page.Controls[3].Controls)
            {
                if(item.GetType().ToString().ToLower().Contains("textbox"))
                {
                    Random rnd = new Random();
                    TextBox txt = (TextBox)item;
                    System.Threading.Thread.Sleep(20);
                    txt.Text = rnd.Next(1, 45).ToString();
                }
            }
        }
