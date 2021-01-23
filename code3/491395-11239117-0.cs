    using System;
    using System.Windows.Forms;
    
    class Foo
    {
        public string Value { get; set; }
        
        public void HandleClick(object sender, EventArgs e)
        {
            ((Control)sender).Text = Value;
        }
    }
    
    class Program
    {
        public static void Main()
        {
            Foo foo = new Foo { Value = "Done" };
            
            Button button = new Button { Text = "Click me!" };
            button.Click += foo.HandleClick;
            
            Form form = new Form
            {
                Controls = { button }
            };
            
            Application.Run(form);
        }
    }
