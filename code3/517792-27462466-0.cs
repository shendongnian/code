    static public class RichTextBoxResizer {  
        static public void ResizeToContents(this RichTextBox richTextBox, ContentsResizedEventArgs e) {  
            richTextBox.Width = e.NewRectangle.Width;  
            richTextBox.Height = e.NewRectangle.Height;  
            
            richTextBox.Width += richTextBox.Margin.Horizontal +  
                SystemInformation.HorizontalResizeBorderThickness +  
                SystemInformation.HorizontalScrollBarThumbWidth;  
                
            richTextBox.Height += richTextBox.Margin.Vertical +  
                SystemInformation.VerticalResizeBorderThickness;  
        }  	
        
        static public void ResizeToContentsHorizontally(this RichTextBox richTextBox, ContentsResizedEventArgs e) {
            richTextBox.Width = e.NewRectangle.Width;
            richTextBox.Width += richTextBox.Margin.Horizontal +
                SystemInformation.HorizontalResizeBorderThickness +
                SystemInformation.HorizontalScrollBarThumbWidth;
        }
        static public void ResizeToContentsVertically(this RichTextBox richTextBox, ContentsResizedEventArgs e) {
            richTextBox.Height = e.NewRectangle.Height;
                        
            richTextBox.Height += richTextBox.Margin.Vertical +
                SystemInformation.VerticalResizeBorderThickness;
        }
    }
	
