    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace FlowLayoutStackoverflow
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                //Load three FLP's
                for (int i = 0; i < 3; i++)
                {
                    var _flowLayoutPanel = new FlowLayoutPanel();
                    _flowLayoutPanel.Name = "Flow" + i;
                    _flowLayoutPanel.Location = new Point(30*i, 30*i);
                    _flowLayoutPanel.Size = new Size(300, 30);
                    _flowLayoutPanel.BackColor = Color.DarkCyan;
                    _flowLayoutPanel.BorderStyle = BorderStyle.Fixed3D;
                    _flowLayoutPanel.Disposed += _flowLayoutPanel_Disposed;
    
                    //Dispose Button
                    var _button = new Button();
                    _button.Text = "Dispose";
                    _button.Name = "DisposeButton" + i;
                    _button.Location = new Point(1*i, 1*i);
                    _button.MouseClick += _button_MouseClick;
    
                    _flowLayoutPanel.Controls.Add(_button);
                    this.Controls.Add(_flowLayoutPanel);
                }
            }
    
            private void _button_MouseClick(object sender, MouseEventArgs e)
            {
                (sender as Button).Parent.Dispose();
            }
    
            //Notify disposal
            private void _flowLayoutPanel_Disposed(object sender, EventArgs e)
            {
                MessageBox.Show(string.Format("Disposed FlowLayoutPanel with name {0}", (sender as FlowLayoutPanel).Name));
            }
        }
    }
