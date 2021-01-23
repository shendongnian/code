    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    namespace TestForm
    {
        class Form1 : Form
        {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;
            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                this.dataGridView1 = new System.Windows.Forms.DataGridView();
                this.ttText = new System.Windows.Forms.ToolTip(this.components);
                ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
                this.SuspendLayout();
                // 
                // dataGridView1
                // 
                this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dataGridView1.Location = new System.Drawing.Point(17, 23);
                this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
                this.dataGridView1.Name = "dataGridView1";
                this.dataGridView1.Size = new System.Drawing.Size(604, 395);
                this.dataGridView1.TabIndex = 0;
                this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_MouseCellEnter);
                this.dataGridView1.MouseLeave += new System.EventHandler(this.dataGridView1_MouseLeave);
                this.dataGridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.event_MouseMove);
                // 
                // ttText
                // 
                this.ttText.AutomaticDelay = 0;
                this.ttText.AutoPopDelay = 0;
                this.ttText.InitialDelay = 10;
                this.ttText.IsBalloon = true;
                this.ttText.OwnerDraw = true;
                this.ttText.ReshowDelay = 0;
                this.ttText.ShowAlways = true;
                this.ttText.UseAnimation = false;
                this.ttText.UseFading = false;
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(637, 433);
                this.Controls.Add(this.dataGridView1);
                this.Margin = new System.Windows.Forms.Padding(4);
                this.Name = "Form1";
                this.Text = "Form1";
                this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.event_MouseMove);
                ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
                this.ResumeLayout(false);
            }
            private System.Windows.Forms.DataGridView dataGridView1;
            private System.Windows.Forms.ToolTip ttText;
            public Form1()
            {
                InitializeComponent();
                dataGridView1.ShowCellToolTips = false;
                var ds = Sayings().ToList();
                dataGridView1.DataSource = ds;
            }
            public List<dynamic> Sayings()
            {
                return new List<dynamic>
                {
                    new 
                    { 
                        Human = "I'm hungry\nand waiting!",
                        BabyBear = "Well, too bad -- so much for your stamina, you should not be here!\nSo the little bear responds!"
                    },
                    new 
                    { 
                        Human = "What a selfish bear!\n\n\nAt least you could do is wait for\nothers to join you!",
                        BabyBear = "Boo Hoo!"
                    },
                    new 
                    { 
                        Human = "Oh, I'm sorry!",
                        BabyBear = "Now, I'm going to eat you!"
                    },
                    new 
                    { 
                        Human = "\n\n\n!!!\n\nWhat?????\n\n\n\nI don't think so!\n\n(Human pulls out Honey Jar)",
                        BabyBear = "Yum!"
                    },
                };
            }
            private void dataGridView1_MouseCellEnter(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex != -1 && e.RowIndex != -1)
                {
                    this.SuspendLayout();
                    var rectC = dataGridView1.GetColumnDisplayRectangle(e.ColumnIndex, true);
                    var left = rectC.Left + (int)(rectC.Width * .5f);
                    var rectR = dataGridView1.GetRowDisplayRectangle(e.RowIndex, true);
                    var top = (rectR.Top + (int)(rectR.Height * .5f));
                    Point displayPoint = new Point(left + this.ClientRectangle.Left, top + this.ClientRectangle.Top + 40);
                    var column = e.ColumnIndex;
                    var row = e.RowIndex;
                    for (int i = 0; i < 5; ++i)
                    {
                        ttText.Show(dataGridView1[column, row].Value.ToString(), this, displayPoint);
                        ttText.Hide(this);
                    }
                    ttText.Show(dataGridView1[column, row].Value.ToString(), this, displayPoint);
                    this.ResumeLayout();
                }
            }
            private void dataGridView1_MouseLeave(object sender, EventArgs e)
            {
                Rectangle mouseRect = new Rectangle(MousePosition, new Size(1, 1));
                var rectC = dataGridView1.GetColumnDisplayRectangle(dataGridView1.Columns.Count - 1, true);
                var right = rectC.Right;
                var rectR = dataGridView1.GetRowDisplayRectangle(dataGridView1.Rows.Count - 1, true);
                var bottom = rectR.Bottom;
                var rect = new Rectangle(
                    dataGridView1.PointToScreen(dataGridView1.Location),
                    new Size(right, bottom));
                if (!rect.IntersectsWith(mouseRect))
                    ttText.Hide(this);
            }
            void event_MouseMove(object sender, MouseEventArgs e)
            {
                dataGridView1_MouseLeave(sender, EventArgs.Empty);
            }
        }
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
