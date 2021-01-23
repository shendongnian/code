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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._axShockwaveFlash = new AxShockwaveFlashObjects.AxShockwaveFlash();
            ((System.ComponentModel.ISupportInitialize)(this._axShockwaveFlash)).BeginInit();
            this.SuspendLayout();
            // 
            // flash
            // 
            this._axShockwaveFlash.Enabled = true;
            this._axShockwaveFlash.Location = new System.Drawing.Point(0, 0);
            this._axShockwaveFlash.Name = "_axShockwaveFlash";
            this._axShockwaveFlash.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("flash.OcxState")));
            this._axShockwaveFlash.Size = new System.Drawing.Size(192, 192);
            this._axShockwaveFlash.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 299);
            this.Controls.Add(this._axShockwaveFlash);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._axShockwaveFlash)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
        private AxShockwaveFlash _axShockwaveFlash;
    }
