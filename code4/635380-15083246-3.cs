    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
    
       public class MyLabel:Label
        {
    
           public MyLabel()
           {
    
           }
           protected override void OnClick(EventArgs e)
           {
               base.OnClick(e);
               MessageBox.Show("Label Clicked");
           }
          
        }
    }
