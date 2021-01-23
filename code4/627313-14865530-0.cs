    using System;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace WindowsFormsApplication5
    {
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
                Application.Run(new MainForm());
            }
        }
        public class MainForm : Form
        {
            private Random random = new Random();
            private Button btnRandomBackgroundColor;
            private Label lblBackgroundLabel;
            private Label lblTransparent;
    
            public MainForm()
            {
                InitializeComponent();
            }
    
            private void button_Click(object sender, EventArgs e)
            {
                BackColor = Color.FromArgb(random.Next(0, 255),
                                                random.Next(0, 255),
                                                random.Next(0, 255));
            }
    
            private void InitializeComponent()
            {
                this.btnRandomBackgroundColor = new System.Windows.Forms.Button();
                this.lblBackgroundLabel = new System.Windows.Forms.Label();
                this.lblTransparent = new System.Windows.Forms.Label();
                this.SuspendLayout();
                // 
                // btnRandomBackgroundColor
                // 
                this.btnRandomBackgroundColor.Location = new System.Drawing.Point(12, 12);
                this.btnRandomBackgroundColor.Name = "btnRandomBackgroundColor";
                this.btnRandomBackgroundColor.Size = new System.Drawing.Size(144, 23);
                this.btnRandomBackgroundColor.TabIndex = 0;
                this.btnRandomBackgroundColor.Text = "Randomize Background Color";
                this.btnRandomBackgroundColor.UseVisualStyleBackColor = true;
                this.btnRandomBackgroundColor.Click += button_Click;
                // 
                // lblBackgroundLabel
                // 
                this.lblBackgroundLabel.AutoSize = true;
                this.lblBackgroundLabel.BackColor = System.Drawing.Color.Transparent;
                this.lblBackgroundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblBackgroundLabel.Location = new System.Drawing.Point(41, 49);
                this.lblBackgroundLabel.Name = "lblBackgroundLabel";
                this.lblBackgroundLabel.Size = new System.Drawing.Size(184, 33);
                this.lblBackgroundLabel.TabIndex = 1;
                this.lblBackgroundLabel.Text = "Simple Label";
                // 
                // lblTransparent
                // 
                this.lblTransparent.AutoSize = true;
                this.lblTransparent.BackColor = System.Drawing.Color.Transparent;
                this.lblTransparent.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblTransparent.Location = new System.Drawing.Point(61, 63);
                this.lblTransparent.Name = "lblTransparent";
                this.lblTransparent.Size = new System.Drawing.Size(251, 33);
                this.lblTransparent.TabIndex = 2;
                this.lblTransparent.Text = "Transparent Label";
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.Color.White;
                this.ClientSize = new System.Drawing.Size(341, 114);
                Controls.Add(this.lblTransparent);
                this.Controls.Add(this.lblBackgroundLabel);
                this.Controls.Add(this.btnRandomBackgroundColor);
                this.Name = "Form1";
                this.Text = "MainForm";
                this.ResumeLayout(false);
                this.PerformLayout();
    
            }
        }
    }
