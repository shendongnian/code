    public class MyTextBox : TextBox {
    
    public String isBetterThan { get; set;}
    public String author {get; set;}
    protected override void OnMouseLeave(MouseEventArgs e)        
    {            
         base.OnMouseLeave(e);
         // do something
         isBetterThan = this.Text;
    }    
    }
