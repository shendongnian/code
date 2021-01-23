     public class buttons
     {
          private Form _form = null;
          public buttons(Form form)
          {
             _form = form;
          }
          public void print(Point buttonLocation, Size buttonSize, string buttonText)
          {
             Button btn = new Button();
             btn.Location = buttonLocation;
             btn.Size = buttonSize;
             btn.Text = buttonText;
             _form.Controls.Add(btn);
          }     
     }
     public class Form1 : Form
     {
         private buttons _buttons = null;
         public Form1()
         {
           _buttons = new buttons(this);
         }
         
         public void foo()
         {
            buttons.print(new System.Drawing.Point(82, 44), new System.Drawing.Size(977, 54), "button text");
         }
     }
