    public class YourUserControl : UserControl {
         public YourUserControl(){
            InitializeComponent();            
         }         
         private void pictureBox_Click(object sender, EventArgs e){
            //your code for pictureBox_Click
            OnClick(e);//This is needed if you want to register some Click event handler from ouside your UserControl.
         }
    }    
