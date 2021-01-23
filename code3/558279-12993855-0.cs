    using System;
    using System.Windows;
    using System.Windows.Forms.Integration;
    using System.Drawing;
    
    namespace WindowsFormsHost_Random_Squares
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                Width = 350;
                Height = 350;
    
                Random random = new Random();
    
                var windowsFormsHost = new WindowsFormsHost();
    
                Content = windowsFormsHost;
    
                var panel = new System.Windows.Forms.Panel()
                { Dock = System.Windows.Forms.DockStyle.Fill };
    
                windowsFormsHost.Child = panel;
    
                panel.Paint += (sender, e) =>
                    {
                        e.Graphics.Clear(System.Drawing.Color.Black);
    
                        for (int i = 0; i < 30; i++)
                            for (int j = 0; j < 30; j++)
                            {
                                if (random.Next(2) == 1)
                                    e.Graphics.FillRectangle(
                                        new SolidBrush(System.Drawing.Color.Red),
                                        i * 10,
                                        j * 10,
                                        10,
                                        10);
                            }
                    };
            }
        }
    }
