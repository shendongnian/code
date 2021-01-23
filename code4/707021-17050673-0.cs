    public class YourUserControl : UserControl {
         public YourUserControl(){
            InitializeComponent();            
         }
         protected override void OnClick(EventArgs e){
             pictureBox_Click(pictureBox, e);
             //base.OnClick(e);
         } 
         private void pictureBox_Click(object sender, EventArgs e){
            //Your code here;
         }
    }    
