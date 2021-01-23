    using System.Windows.Forms;
    
    class Test
    {   
        static void Main()
        {
            Label label = new Label { Text = "Click me" };
            label.Click += delegate { label.Text = "Clicked"; };
            Application.Run(new Form { Controls = { label } });
        }
    }
