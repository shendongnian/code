     public partial class Form1 : Form
     {
        Namespace.Form2 form2 = (Namespace.Form2)Application.OpenForms[1];
        
        //Single Button event handler    
        private void onOffClick(object sender, EventArgs e)
        {
               form2.LableName.Visible = !form2.LabelName.Visibility;
        }
    }
