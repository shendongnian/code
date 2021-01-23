    using System.Windows.Forms;
    
    class Program
    {
        private static Random Random = new Random();
    
        static void Main()
        {
            var label = new Label { Text = "Click me!" };
            label.Click += delegate { RandomizeLocation(label); };
            
            EventHandler Load = delegate {
                RandomizeLocation(label);
            };
            
            var form = new Form { Controls = { label } };
            form.Load += Load;
            
            Application.Run(form);
        }
        
        private static void RandomizeLocation(Control control)
        {
            var maxWidth = control.Parent.Width - control.Width;
            var maxHeight = control.Parent.Height - control.Height;
            var x = Random.Next(maxWidth);
            var y = Random.Next(maxHeight);
            control.Location = new Point(x, y);
        }
    }
