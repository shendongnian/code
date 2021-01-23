     StringBuilder builder = new StringBuilder();
     using (StreamReader sr = File.OpenText(newPath)) {
         while ((input = sr.ReadLine()) != null) {
             builder.AppendLine(input);
         }
     }
     TextBox1.Text = builder.ToString();
