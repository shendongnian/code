    using System.Windows.Forms;
    
    class Program
    {
        private static Random Random = new Random();
    
        static void Main()
        {
            var label = new Label { Text = "Click me!" };
            label.Click += delegate { label.Text = "Clicked!"; };
            
            EventHandler Load = delegate {
                var maxWidth = label.Parent.Width - label.Width;
                var maxHeight = label.Parent.Height - label.Height;
                var x = Random.Next(maxWidth);
                var y = Random.Next(maxHeight);
    
                label.Location = new Point(x, y);
            };
            
            var form = new Form { Controls = { label } };
            form.Load += Load;
            
            Application.Run(form);
        }
    }
