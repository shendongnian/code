    using System;
    using System.Windows.Forms;
    
    class Program
    {
        public static void Main()
        {
            var b1 = new RadioButton { Text = "Button 1" };
            var b2 = new RadioButton { Text = "Button 2" };
            
            EventHandler handler = (sender, args) => {
                RadioButton button = (RadioButton) sender;
                Console.WriteLine("{0} {1}",
                    button.Text,
                    button.Checked ? "Checked" : "Unchecked");
            };
                
            b1.CheckedChanged += handler;
            b2.CheckedChanged += handler;
            
            var form = new Form {
                Controls = {
                    new FlowLayoutPanel {
                        FlowDirection = FlowDirection.TopDown,
                        Controls = { b1, b2 }
                    }
                }
            };
            Application.Run(form);
        }    
    }
