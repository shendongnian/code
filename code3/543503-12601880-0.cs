    using System.Drawing;
    
    class newLabel:System.Windows.Forms.Label
    {
        public int RotateAngle { get; set; }  
        public string NewText { get; set; }   
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Brush b =new SolidBrush(this.ForeColor);           
            e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            e.Graphics.RotateTransform(this.RotateAngle);
            e.Graphics.DrawString(this.NewText, this.Font,b , 0f, 0f);
            base.OnPaint(e);
        }
    }
    Now this custom control is used into your form.
    
    You have to set below properties
    
     newlbl.Text = "";           
      newlbl.AutoSize = false;      
      newlbl.NewText = "ravindra";     
      newlbl.ForeColor = Color.Green;  
      newlbl.RotateAngle = -90; 
