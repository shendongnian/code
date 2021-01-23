            private void button_Click(object sender, EventArgs e)
            {
                Button clickedBtn = sender as Button;
                var cp = tableLayoutPanel1.GetCellPosition(clickedBtn);
    
                Button up = (Button)tableLayoutPanel1.GetControlFromPosition(cp.Column, cp.Row - 1);
                //up.Color = ...
                Button down = (Button)tableLayoutPanel1.GetControlFromPosition(cp.Column, cp.Row + 1);
                //etc
            }
