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
    
            //Store Panels
            List<FlowLayoutPanel> FlowLayoutPanels = new List<FlowLayoutPanel>();
    
            private void Form1_Load(object sender, EventArgs e)
            {
                //Button to dispose the FlowLayoutPanels
                Button DisposeButton = new Button();
                DisposeButton.Name = "DisposeButton";
                DisposeButton.Text = "Dispose All FlowLayoutPanels";
                DisposeButton.MouseClick += DisposeButton_MouseClick;
                DisposeButton.Location = new Point(150,150);
                this.Controls.Add(DisposeButton);
    
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
    
                    var _button = new Button();
                    _button.Text = "submit";
                    _button.Name = "but" + i;
                    _button.Location = new Point(1*i, 1*i);
    
                    _flowLayoutPanel.Controls.Add(_button);
                    this.Controls.Add(_flowLayoutPanel);
                    FlowLayoutPanels.Add(_flowLayoutPanel);
                }
            }
    
            //Notify disposal
            private void _flowLayoutPanel_Disposed(object sender, EventArgs e)
            {
                MessageBox.Show(string.Format("Disposed FlowLayoutPanel with name {0}", (sender as FlowLayoutPanel).Name));
            }
    
            //Dispose all
            private void DisposeButton_MouseClick(object sender, MouseEventArgs e)
            {
                foreach (var flowControl in FlowLayoutPanels)
                {
                    this.Controls.Remove(flowControl);
                    flowControl.Dispose();
                }
                FlowLayoutPanels.Clear();
            }
        }
    }
