         public class Compare
         {
             public void Comparator()
             {
                 progressBar.Value = 0;
                 progressBar.Maximum = val;
                 progressBar.Step = 1;
                 for (int i;i<val;i++)
                 { 
                     /* ............. */ 
                     progressBar.PerformStep();
                 }
             }
         }
