    public partial class Form1 : Form  
    {  
       // Comobox and textbox are global
       ComboBox c1;
       TextBox t1;
  
       public Form1()  
       {  
           InitializeComponent();  
           c1 = new ComboBox();  
  
           //todo: add your combox init here
           t1 = new TextBox();
  
           // Set button values  
           t1.Text = "Button";  
  
           // Add the event handler  
           t1.KeyPress += new KeyPressEventHandler(this.KeyPressEvent);  
  
          // Add the textbox to the form  
          this.Controls.Add(c1);
          this.Controls.Add(t1);  
       }  
  
  
       // Keypress event  
       private void KeyPressEvent(object sender, KeyPressEventArgs e)  
       {  
           MessageBox.Show(t1.Text);  
           // from here you can also access c1
       }  
   }  
