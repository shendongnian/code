    private void ToolStripComboBoxSpeed_SelectedIndexChanged (object sender, System.EventArgs e)
    {
        this.RenderSpeed = (int) this.ToolStripComboBoxSpeed.SelectedItem;
        Switch (this.RenderSpeed)
        {
            case 5: TimerGuide.Interval = 50; break;
            case 10: TimerGuide.Interval = 40; break;
            case 15: TimerGuide.Interval = 30; break;
            case 20: TimerGuide.Interval = 20; break;
            case 25: TimerGuide.Interval = 10; break;
        }
    }
    private void PictureBox_Paint (object sender, System.Windows.Forms.PaintEventArgs e)
    {
       //
       // '~~> Rest of the code remains same
       //
                
       //this.RenderGuidePoint.Offset(this.RenderSpeed, 0);
       this.RenderGuidePoint.Offset(1, 0);
       //
       // '~~> Rest of the code remains same
       //
    }
