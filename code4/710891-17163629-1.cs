    public class YourControl : TheBaseControl {
         protected override void OnParentChanged(EventArgs e){
           if(Parent != null){
              Parent.FontChanged -= ParentFontChanged;
              Parent.FontChanged += ParentFontChanged;
           }
         }
         private void ParentFontChanged(object sender, EventArgs e){
           Font = new Font(Font.FontFamily, Parent.Font.Size, Font.Style);
         }
    }
