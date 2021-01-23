    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
      partial class Form_1:Form 
      {
    
        public Form_1()
        {
          InitializeComponent();
    
        }
    
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
    
        private void InitializeComponent()
        {
          this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
          this.panel4 = new System.Windows.Forms.Panel();
          this.panel3 = new System.Windows.Forms.Panel();
          this.panel2 = new System.Windows.Forms.Panel();
          this.panel1 = new System.Windows.Forms.Panel();
          this.tableLayoutPanel1.SuspendLayout();
          this.SuspendLayout();
          // 
          // tableLayoutPanel1
          // 
          this.tableLayoutPanel1.ColumnCount = 2;
          this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
          this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
          this.tableLayoutPanel1.Controls.Add(this.panel4, 3, 0);
          this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
          this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
          this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
          this.tableLayoutPanel1.SetRowSpan(this.panel1, 3);//This line is the key!!!!!
          this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
          this.tableLayoutPanel1.Name = "tableLayoutPanel1";
          this.tableLayoutPanel1.RowCount = 3;
          this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
          this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
          this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
          this.tableLayoutPanel1.Size = new System.Drawing.Size(527, 372);
          this.tableLayoutPanel1.TabIndex = 0;
          // 
          // panel4
          // 
          this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
          this.panel4.Location = new System.Drawing.Point(134, 251);
          this.panel4.Name = "panel4";
          this.panel4.Size = new System.Drawing.Size(390, 118);
          this.panel4.TabIndex = 4;
          // 
          // panel3
          // 
          this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
          this.panel3.Location = new System.Drawing.Point(134, 127);
          this.panel3.Name = "panel3";
          this.panel3.Size = new System.Drawing.Size(390, 118);
          this.panel3.TabIndex = 3;
          // 
          // panel2
          // 
          this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
          this.panel2.Location = new System.Drawing.Point(134, 3);
          this.panel2.Name = "panel2";
          this.panel2.Size = new System.Drawing.Size(390, 118);
          this.panel2.TabIndex = 2;
          // 
          // panel1
          // 
          this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.panel1.Location = new System.Drawing.Point(3, 3);
          this.panel1.Name = "panel1";
          this.panel1.Size = new System.Drawing.Size(125, 366);
          this.panel1.TabIndex = 1;
          // 
          // Form1
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(527, 372);
          this.Controls.Add(this.tableLayoutPanel1);
          this.Name = "Form1";
          this.Text = "Form1";
          this.tableLayoutPanel1.ResumeLayout(false);
          this.ResumeLayout(false);
    
        }
    
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
      }
    }
