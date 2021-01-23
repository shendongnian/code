    namespace testowa
    {
        partial class Form1
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
    
            #region Windows Form Designer generated code
    
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.menuStrip1 = new System.Windows.Forms.MenuStrip();
                this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
                this.GRID = new System.Windows.Forms.DataGridView();
                this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                this.menuStrip1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.GRID)).BeginInit();
                this.SuspendLayout();
                // 
                // menuStrip1
                // 
                this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                    this.fileToolStripMenuItem});
                this.menuStrip1.Location = new System.Drawing.Point(0, 0);
                this.menuStrip1.Name = "menuStrip1";
                this.menuStrip1.Size = new System.Drawing.Size(651, 24);
                this.menuStrip1.TabIndex = 0;
                this.menuStrip1.Text = "menuStrip1";
                // 
                // fileToolStripMenuItem
                // 
                this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                    this.saveToolStripMenuItem,
                    this.openToolStripMenuItem,
                    this.closeToolStripMenuItem});
                this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
                this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
                this.fileToolStripMenuItem.Text = "File";
                // 
                // saveToolStripMenuItem
                // 
                this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
                this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
                this.saveToolStripMenuItem.Text = "Save";
                this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
                // 
                // openToolStripMenuItem
                // 
                this.openToolStripMenuItem.Name = "openToolStripMenuItem";
                this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
                this.openToolStripMenuItem.Text = "Open";
                this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
                // 
                // closeToolStripMenuItem
                // 
                this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
                this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
                this.closeToolStripMenuItem.Text = "Close";
                this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
                // 
                // openFileDialog1
                // 
                this.openFileDialog1.FileName = "openFileDialog1";
                this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
                // 
                // GRID
                // 
                this.GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.GRID.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                    this.Column1,
                    this.Column2,
                    this.Column3,
                    this.Column4});
                this.GRID.Location = new System.Drawing.Point(13, 28);
                this.GRID.Name = "GRID";
                this.GRID.Size = new System.Drawing.Size(451, 232);
                this.GRID.TabIndex = 1;
                this.GRID.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
                // 
                // Column1
                // 
                this.Column1.HeaderText = "name";
                this.Column1.Name = "Column1";
                // 
                // Column2
                // 
                this.Column2.HeaderText = "last name";
                this.Column2.Name = "Column2";
                // 
                // Column3
                // 
                this.Column3.HeaderText = "City";
                this.Column3.Name = "Column3";
                // 
                // Column4
                // 
                this.Column4.HeaderText = "Phone #";
                this.Column4.Name = "Column4";
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(651, 262);
                this.Controls.Add(this.GRID);
                this.Controls.Add(this.menuStrip1);
                this.MainMenuStrip = this.menuStrip1;
                this.Name = "Form1";
                this.Text = "Form1";
                this.menuStrip1.ResumeLayout(false);
                this.menuStrip1.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.GRID)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();
    
            }
    
            #endregion
    
            private System.Windows.Forms.MenuStrip menuStrip1;
            private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
            private System.Windows.Forms.OpenFileDialog openFileDialog1;
            private System.Windows.Forms.DataGridView GRID;
            private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
            private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
            private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
            private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
            private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        }
    }
