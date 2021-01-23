    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace Test
    {
        class mainWindow : Form
        {
            // since u need to access the control, u need to keep that control at global level
            private Button firstButton = null;
            private Label firstLabel = null;
            public mainWindow()
            {
                firstLabel = new Label();
                firstLabel.Text = "Hello";
                Controls.Add(firstLabel);
                Button firstButton = new Button();
                firstButton.Text = "Click me";
                firstButton.Click += firstButton_Click;
                firstButton.Left = 100;
                Controls.Add(firstButton);
            }
            void firstButton_Click(object sender, EventArgs e)
            {
                // now since the variable is global u can access it and change the title
                firstLabel.Text = "Goodbye";
            }
        }
        static class XxX
        {
            static void Main()
            {
                mainWindow form = new mainWindow();
                Application.Run(form);
            }
        }
    }
