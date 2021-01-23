       Use the Parameter of Second Form in *First Form*:-
       namespace PassValue
       {
          public partial class Form1 : Form
          {
             public Form1()
             {
                InitializeComponent();
             }
             private void Button1_Click(object sender, EventArgs e)
             {
                 Form2 f2=new Form2(Textbox.Text);
                 f2.Show();
             }
          }
       }
