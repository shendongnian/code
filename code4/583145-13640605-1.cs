    namespace WindowsFormsApplication1
    {
        partial class Form1
        {
            private System.ComponentModel.IContainer components = null;  
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
    
            #region designer
            private void InitializeComponent()
            {
                this.gridControl1 = new DevExpress.XtraGrid.GridControl();
                this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
                this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
                this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
                this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
                ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
                this.SuspendLayout();
                // 
                // gridControl1
                // 
                this.gridControl1.Location = new System.Drawing.Point(13, 13);
                this.gridControl1.MainView = this.gridView1;
                this.gridControl1.Name = "gridControl1";
                this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                this.repositoryItemCheckEdit1});
                this.gridControl1.Size = new System.Drawing.Size(350, 329);
                this.gridControl1.TabIndex = 0;
                this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                this.gridView1});
                // 
                // gridView1
                // 
                this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.gridColumn1,
                this.gridColumn2});
                this.gridView1.GridControl = this.gridControl1;
                this.gridView1.Name = "gridView1";
                this.gridView1.OptionsSelection.MultiSelect = true;
                // 
                // gridColumn1
                // 
                this.gridColumn1.Caption = "gridColumn1";
                this.gridColumn1.ColumnEdit = this.repositoryItemCheckEdit1;
                this.gridColumn1.FieldName = "CHECK";
                this.gridColumn1.Name = "gridColumn1";
                this.gridColumn1.Visible = true;
                this.gridColumn1.VisibleIndex = 0;
                // 
                // repositoryItemCheckEdit1
                // 
                this.repositoryItemCheckEdit1.AutoHeight = false;
                this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
                // 
                // gridColumn2
                // 
                this.gridColumn2.Caption = "gridColumn2";
                this.gridColumn2.FieldName = "DAY";
                this.gridColumn2.Name = "gridColumn2";
                this.gridColumn2.Visible = true;
                this.gridColumn2.VisibleIndex = 1;
                // 
                // simpleButton1
                // 
                this.simpleButton1.Location = new System.Drawing.Point(369, 12);
                this.simpleButton1.Name = "simpleButton1";
                this.simpleButton1.Size = new System.Drawing.Size(75, 23);
                this.simpleButton1.TabIndex = 1;
                this.simpleButton1.Text = "Checked >>";
                this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                // 
                // simpleButton2
                // 
                this.simpleButton2.Location = new System.Drawing.Point(369, 41);
                this.simpleButton2.Name = "simpleButton2";
                this.simpleButton2.Size = new System.Drawing.Size(75, 23);
                this.simpleButton2.TabIndex = 2;
                this.simpleButton2.Text = "Selected >>";
                this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                // 
                // memoEdit1
                // 
                this.memoEdit1.Location = new System.Drawing.Point(450, 11);
                this.memoEdit1.Name = "memoEdit1";
                this.memoEdit1.Size = new System.Drawing.Size(299, 331);
                this.memoEdit1.TabIndex = 3;
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(964, 665);
                this.Controls.Add(this.memoEdit1);
                this.Controls.Add(this.simpleButton2);
                this.Controls.Add(this.simpleButton1);
                this.Controls.Add(this.gridControl1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.Load += new System.EventHandler(this.Form1_Load);
                ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
                this.ResumeLayout(false);
            }
    
            #endregion
    
            private DevExpress.XtraGrid.GridControl gridControl1;
            private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
            private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
            private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
            private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
            private DevExpress.XtraEditors.SimpleButton simpleButton1;
            private DevExpress.XtraEditors.SimpleButton simpleButton2;
            private DevExpress.XtraEditors.MemoEdit memoEdit1;
        }
    }
