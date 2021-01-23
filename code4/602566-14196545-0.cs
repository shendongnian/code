    private int clickNo = 0;
    private void DrawingPanel_MouseClick(object sender, MouseEventArgs e)
    {  
       if (e.Button == MouseButtons.Left)
       {
           clickNo++;
           switch (clickNo)
           {
               case 1: Foo(); break;
               case 2: Bar(); break;
               case 3: Baz(); clickNo = 0; break;
           }
       }
    }
