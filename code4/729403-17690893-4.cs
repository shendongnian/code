    public class Form1 : Form {
       public Form1(){
          InitializeComponent();
          //I suppose buttons is your buttons array defined somewhere.
          int m = 0;
          foreach (Button button in buttons)
            {
                Binding bind = new Binding("Width", this, "MaxWidth");
                bind.DataSourceUpdateMode = DataSourceUpdateMode.Never;//This is important
                button.DataBindings.Add(bind);        
                button.AutoSize = true;     
                if(button.Width > m) m = button.Width;
                button.SizeChanged += (s, e) =>
                {
                    Button but = s as Button;
                    if (but.Width > MaxWidth)
                    {
                        but.DataBindings["Width"].WriteValue();
                    } else but.Width = MaxWidth;
                };
            }
            ButtonMaxWidth = m;//Initialize the max width, this is done only once and you don't have to loop through your buttons to update the max width because it's done via the mechanism of `Binding` and `event`.
            //Try changing the Width of any button in your buttons array
            buttons[2].Width = 300;//if this > MaxWidth, all the buttons will change its Width to the new same MaxWidth, otherwise they will stay on the current MaxWidth.            
            //Try changing the Text of one of your buttons
            buttons[1].Text = "I love Windows Presentation Foundation";
       }
       public int ButtonMaxWidth {get;set;}
    }
