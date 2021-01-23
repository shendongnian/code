    using System;
    using System.Windows.Forms;
    using System.Drawing;
    
    //$/t:winexe
    //& RunInOwnWindow
    
    namespace PowerAPP
    {
        public class MainForm : Form
        {
            #region  Initialization
            private System.Windows.Forms.GroupBox groupBox1;
            private System.Windows.Forms.Button button1;
            private System.Windows.Forms.TextBox textBox1;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.TextBox textBox2;
            private System.Windows.Forms.Label label2;
            
            private static void Main(string [] args)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            MainForm()
            {
                groupBox1 = new System.Windows.Forms.GroupBox();
                button1 = new System.Windows.Forms.Button();
                textBox1 = new System.Windows.Forms.TextBox();
                label1 = new System.Windows.Forms.Label();
                textBox2 = new System.Windows.Forms.TextBox();
                label2 = new System.Windows.Forms.Label();
    
                // button1
                button1.Name = "Button1";
                button1.Location = new System.Drawing.Point(101, 90);
                button1.Size = new System.Drawing.Size(75, 24);
                button1.Text = "button1";
    
                // textBox1
                textBox1.Name = "TextBox1";
                textBox1.Location = new System.Drawing.Point(76, 25);
                textBox1.Size = new System.Drawing.Size(100, 20);
    
                // label1
                label1.Name = "Label1";
                label1.Bounds = new Rectangle(35, 22, 146, 28);
                label1.BackColor = System.Drawing.Color.Yellow;
                label1.Text = "label1";
    
                // textBox2
                textBox2.Name = "TextBox2";
                textBox2.Location = new System.Drawing.Point(76, 55);
                textBox2.Size = new System.Drawing.Size(100, 20);
    
                // label2
                label2.Name = "Label2";
                label2.Bounds = new Rectangle(35, 52, 146, 28);
                label2.BackColor = System.Drawing.Color.Yellow;
                label2.Text = "label2";
                
                groupBox1.Name = "GroupBox1";
                groupBox1.Controls.Add(button1);
                groupBox1.Controls.Add(textBox1);
                groupBox1.Controls.Add(label1);
                groupBox1.Controls.Add(textBox2);
                groupBox1.Controls.Add(label2);
    
                groupBox1.Location = new System.Drawing.Point(35, 34);
                groupBox1.Size = new System.Drawing.Size(200, 128);
                groupBox1.Text = "groupBox1";
    
                // MainFORm
                Name = "MainFOrm";
                ClientSize = new System.Drawing.Size(292, 266);
                Controls.Add(groupBox1);
                Text = "Click Fields to include";
                MouseClick += new System.Windows.Forms.MouseEventHandler(MainForm_MouseClick);
                
                groupBox1.Enabled = false;
            }
            #endregion
    
            private void MainForm_MouseClick(object sender, MouseEventArgs e)
            {
                Point pt = new Point(e.X, e.Y);
                Locate_Point_in_Control_Bounds(this, pt);
            }
    
            private void Locate_Point_in_Control_Bounds(Control ctl, Point pt)
            {
                Rectangle r;
                if (ctl is Form || ctl.HasChildren)
                {
                    foreach (Control c in ctl.Controls)
                    {
                        if (c.HasChildren) Locate_Point_in_Control_Bounds(c, pt);
                        r = c.Bounds;
                        r.Offset(ctl.Left, ctl.Top);
                        if (r.Contains(pt))
                            MessageBox.Show(c.Name);
                    }
                }
                else
                {
                    r = ctl.Bounds;
                    r.Offset(ctl.Left, ctl.Top);
                    if (r.Contains(pt))
                        MessageBox.Show(ctl.Name);
                }
            }
        }
    }
