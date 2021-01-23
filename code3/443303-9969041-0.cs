      using(StreamWriter sw = 
                new System.IO.StreamWriter(fs, 
                    System.Text.UTF8Encoding))
      {
         sw.Write(textBox1.Text);
      }
