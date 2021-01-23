    private void myPanel_Click(object sender, EventArgs e)
    {
       Panel p = (Panel)sender;
       switch ((int)p.Tag )
       {
           case 1:
               // Your Code for Panel 1
               break;
           case 2:
               // Your Code for Panel 2 
               break;
           // Your other Panels here
           default:
               break;
       }
    }
