    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    using System.Collections.Generic;
    
    
    namespace help
    {
    public partial class Form1 : Form
    {
        Thread t1;
        Thread t2;
        Thread t3;
        delegate void CTMethod(int val);
        delegate void CTFinish(string t);
        Queue<string> order = new Queue<string>();        
        #region Variables of Designer File
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        #endregion
        public Form1()
        {
            #region Designer Code I have Cut and Pasted Here
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(161, 268);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Green;
            this.pictureBox2.Location = new System.Drawing.Point(383, 268);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Blue;
            this.pictureBox3.Location = new System.Drawing.Point(605, 268);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 50);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(161, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(383, 25);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(605, 26);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.PerformLayout();
            #endregion
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int r = 490;// int.Parse(textBox1.Text);
            int y = 490;// int.Parse(textBox2.Text);
            int g = 490;// int.Parse(textBox3.Text);
            t1 = new Thread(new ParameterizedThreadStart(loopRed));
            t2 = new Thread(new ParameterizedThreadStart(loopGreen));
            t3 = new Thread(new ParameterizedThreadStart(loopBlue));
            t1.Start(r);
            t2.Start(y);
            t3.Start(g);
        }
        private void updateRed(int val)
        {
            pictureBox1.Width++;
            pictureBox1.Left--;
            pictureBox1.Refresh();
        }
        private void updateGreen(int val)
        {
            pictureBox2.Height++;
            pictureBox2.Top--;
            pictureBox2.Refresh();
        }
        private void updateBlue(int val)
        {
            pictureBox3.Width++;
            pictureBox3.Refresh();
        }
        private void loopRed(object o)
        {
            int c = (int)o;
            CTMethod ctRed = new CTMethod(updateRed);
            if (c < 500)
            {
                for (int i = 0; i < c; i++)
                {
                    if (pictureBox1.Left > 0)
                    {
                        this.Invoke(ctRed, i);
                        Thread.Sleep(20);
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter a value less than 500 for Red Box!!!");
            }
            CTFinish CTFin = new CTFinish(Threadfinish);
            this.Invoke(CTFin, "Red");
        }
        private void loopGreen(object o)
        {
            int c = (int)o;
            CTMethod ctGreen = new CTMethod(updateGreen);
            if (c < 500)
            {
                for (int i = 0; i < c; i++)
                {                    
                    if (pictureBox2.Top > 0 && pictureBox2.Top != textBox2.Top + textBox2.Height)
                    {
                        this.Invoke(ctGreen, i);
                        Thread.Sleep(20);
                    }
                    else
                        break;
                }
            }
            else
            {
                MessageBox.Show("Enter a valure less than 500 for Green Box!!!");
            }
            CTFinish CTFin = new CTFinish(Threadfinish);
            this.Invoke(CTFin, "Green");
        }
        private void loopBlue(object o)
        {
            int c = (int)o;
            CTMethod ctBlue = new CTMethod(updateBlue);
            if (c < 500)
            {
                for (int i = 0; i < c; i++)
                {
                    if (pictureBox3.Left + pictureBox3.Width < this.Width)
                    {
                        this.Invoke(ctBlue, i);
                        Thread.Sleep(20);
                    }
                    else
                        break;
                }
            }
            else
            {
                MessageBox.Show("Enter a valure less than 500 for Blue Box!!!");
            }
            CTFinish CTfin = new CTFinish(Threadfinish);
            this.Invoke(CTfin, "Blue");
        }
        private void Threadfinish(string t)
        {
            order.Enqueue(t);
            if (order.Count == 3)
            {
                MessageBox.Show("Threads finished in this order: \n" + "1." + order.Dequeue() + "\n" + "2." + order.Dequeue()
                    + "\n" + "3." + order.Dequeue() + "\n", "finished");
            }
        }
    }
    }
