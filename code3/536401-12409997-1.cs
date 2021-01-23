            private void loadDataSelector()
        {
            //Initialize the DataSelector
            DataSelector = new AXQDataSelector(getClsidFromProgId("QDataSelLib.QDataSel"));
            if (DataSelector != null)
            {
                System.Reflection.FieldInfo f =
                    typeof(AxHost).GetField("licenseKey",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance);
                f.SetValue(DataSelector, "license-here");
                                
                splitContainer1.Panel2.Controls.Add(DataSelector);
                ((System.ComponentModel.ISupportInitialize)(DataSelector)).BeginInit();
                this.DataSelector.Dock = System.Windows.Forms.DockStyle.Fill;
                this.DataSelector.Enabled = true;
                this.DataSelector.Location = new System.Drawing.Point(0, 0);
                this.DataSelector.Name = "DataSelector";
                this.DataSelector.Size = new System.Drawing.Size(324, 773);
                this.DataSelector.TabIndex = 0;
                splitContainer1.Panel2.ResumeLayout();
                ((System.ComponentModel.ISupportInitialize)(DataSelector)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();
            }
            else
            {
                return;
            }
        }
