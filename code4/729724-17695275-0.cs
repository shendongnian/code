    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.SuspendLayout();
        // 
        // timer1
        // 
        this.timer1.Enabled = true;
        this.timer1.Interval = 1000;
        this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        // 
        // AnalogClock
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Name = "AnalogClock";
        this.Resize += new System.EventHandler(this.AnalogClock_Resize);
        this.Load += new System.EventHandler(this.AnalogClock_Load);
        this.Paint += new System.Windows.Forms.PaintEventHandler(this.AnalogClock_Paint);
        this.ResumeLayout(false);
    }
