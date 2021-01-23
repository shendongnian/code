     private void AggiornaContatore()
     {         
         if(this.lblCounter.InvokeRequired)
         {
             this.lblCounter.BeginInVoke((MethodInvoker) delegate() {this.lblCounter.Text = this.index.ToString(); ;});    
         }
         else
         {
             this.lblCounter.Text = this.index.ToString(); ;
         }
     }
