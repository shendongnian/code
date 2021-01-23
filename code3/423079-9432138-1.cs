    StringBuilder sb = new StringBuilder();
    using (StreamReader sr = new StreamReader("lastupdate.txt")) 
    {
        while (sr.Peek() >= 0) 
        {
            sb.Append(sr.ReadLine());
        }
    }
    textbox.Text = sb.Tostring();
