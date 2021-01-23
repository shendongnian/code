        public partial class ucLabel : Label
        {
            private ToolTip _tt = new ToolTip();
    
            public string TooltipText { get; set; }
    
            public ucLabel() : base() {
                _tt.AutoPopDelay = 1500;
                _tt.InitialDelay = 400;
    //            _tt.IsBalloon = true;
                _tt.UseAnimation = true;
                _tt.UseFading = true;
                _tt.Active = true;
                this.MouseEnter += new EventHandler(this.ucLabel_MouseEnter);
            }
    
            private void ucLabel_MouseEnter(object sender, EventArgs ea)
            {
                if (!string.IsNullOrEmpty(this.TooltipText))
                {
                    _tt.SetToolTip(this, this.TooltipText);
                    _tt.Show(this.TooltipText, this.Parent);
                }
            }
        }
