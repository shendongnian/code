    class HexBox : UserControl{
    
       // .. 
    }
    
    public class MyForm :Form{
      public MyForm(){
        HexBox hexBox = new HexBox();
        Controls.Add(hexBox);
        hexBox.MouseDown += (sender, args) =>{
           // call your scroll to function 
        };
    
        InitializeComponent();
    
      }
    }
