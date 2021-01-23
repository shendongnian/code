        private void Form1_FontChanged(object sender, EventArgs e){
           UpdateChildrenFont(this);
        }
        private void UpdateChildrenFont(Control parent){
           foreach(Control c in parent.Controls){
               c.Font = new Font(c.Font.FontFamily, parent.Font.Size, c.Font.Style);
               UpdateChildrenFont(c);
           }
        }
