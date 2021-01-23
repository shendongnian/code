            private bool clicado = false;
            private Point lm = new Point();
            void PnMouseDown(object sender, System.Windows.Input.MouseEventArgs e)
            {
                clicado = true;
                this.lm = System.Windows.Forms.Control.MousePosition;
                this.lm.X = Convert.ToInt16(this.Left) - this.lm.X;
                this.lm.Y = Convert.ToInt16(this.Top) - this.lm.Y;
            }
    
            void PnMouseUp(object sender, System.Windows.Input.MouseEventArgs e)
            {
                clicado = false;
            }
    
            void PnMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
            {
                if (clicado)
                {
                    this.Left = (System.Windows.Forms.Control.MousePosition.X + this.lm.X);
                    this.Top = (System.Windows.Forms.Control.MousePosition.Y + this.lm.Y);
                }
            }
