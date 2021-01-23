       DialogResult form1Result;
         using (var f = new Form1())
         {
            form1Result = f.ShowDialog();
         }
         if (form1Result == DialogResult.OK)
         {
            using (var f2 = new Form2())
            {
               f2.ShowDialog();
            }
         } 
