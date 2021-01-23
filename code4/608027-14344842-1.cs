            private System.Windows.Forms.TrackBar[] trackBar = new System.Windows.Forms.TrackBar[3];
            [...]
            this.SuspendLayout();
       
            for(int n = 0; n < 3; n++) {
                this.trackBar[n] = new System.Windows.Forms.TrackBar();
                ((System.ComponentModel.ISupportInitialize)(this.trackBar[n])).BeginInit();
                this.trackBar[n].Location = new System.Drawing.Point(154, 80 + n*52);
                this.trackBar[n].Name = "trackBar[" + n + "]";
                this.trackBar[n].Size = new System.Drawing.Size(104, 45);
                this.trackBar[n].TabIndex = 0;
            }
