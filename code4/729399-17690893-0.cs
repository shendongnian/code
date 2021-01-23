    public class Form1 : Form {
       public Form1(){
          InitializeComponent();
          //I suppose buttons is your buttons array defined somewhere.
          foreach (Button button in buttons)
            {
                button.DataBindings.Add("Width", this, "MaxWidth");
                button.Height = 50;//It's up to you                
                button.SizeChanged += (s, e) =>
                {
                    Button but = s as Button;
                    if (but.Width > MaxWidth)
                    {
                        MaxWidth = but.Width;
                        but.DataBindings["Width"].WriteValue();
                    }
                };
                //Try changing the Width of any button in your buttons array
                buttons[2].Width = 300;//if the this > MaxWidth, all the buttons will change its Width to the new same MaxWidth, otherwise they will stay on the current MaxWidth.
            }
       }
       public int ButtonMaxWidth {get;set;}
    }
