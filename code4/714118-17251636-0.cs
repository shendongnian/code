       string line;
       while ((line = sr.ReadLine()) != null)
       {
          txt += line + "\n";
          if (txt != null) richTextBox1.Text += txt;
          else sr.Dispose(); // Remove after seeing below
       }
