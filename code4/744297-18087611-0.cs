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
        this.lblMessage = new System.Windows.Forms.Label();
        this.btnRight = new System.Windows.Forms.Button();
        this.btnLeft = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // lblMessage
        // 
        this.lblMessage.AutoSize = true;
        this.lblMessage.Location = new System.Drawing.Point(12, 39);
        this.lblMessage.Name = "lblMessage";
        this.lblMessage.Size = new System.Drawing.Size(35, 13);
        this.lblMessage.TabIndex = 0;
        this.lblMessage.Text = "label1";
        // 
        // btnRight
        // 
        this.btnRight.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        this.btnRight.Location = new System.Drawing.Point(89, 73);
        this.btnRight.Name = "btnRight";
        this.btnRight.Size = new System.Drawing.Size(75, 23);
        this.btnRight.TabIndex = 1;
        this.btnRight.UseVisualStyleBackColor = true;
        // 
        // btnLeft
        // 
        this.btnLeft.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        this.btnLeft.Location = new System.Drawing.Point(8, 73);
        this.btnLeft.Name = "btnLeft";
        this.btnLeft.Size = new System.Drawing.Size(75, 23);
        this.btnLeft.TabIndex = 0;
        this.btnLeft.UseVisualStyleBackColor = true;
        // 
        // CustomMessageBox
        // 
        this.AcceptButton = this.btnLeft;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.AutoSize = true;
        this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        this.ClientSize = new System.Drawing.Size(170, 114);
        this.ControlBox = false;
        this.Controls.Add(this.btnLeft);
        this.Controls.Add(this.btnRight);
        this.Controls.Add(this.lblMessage);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.KeyPreview = true;
        this.MinimumSize = new System.Drawing.Size(176, 120);
        this.Name = "CustomMessageBox";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "CustomMessageBox";
        this.Load += new System.EventHandler(this.frmCustomMessageBoxLoad);
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    #endregion
    private System.Windows.Forms.Label lblMessage;
    private System.Windows.Forms.Button btnRight;
    private System.Windows.Forms.Button btnLeft;
    
