    foreach(Control ctrl in pnl.Controls){
        if(ctrl is Checkbox){
            Checkbox chk = ctrl as Checkbox;
            if(chk.Checked){
                switch(chk.Name){
                    case "chkSeat1":
                        writer.WriteLine(chk.Text);
                        break;
                    case "chkSeat2":
                        writer.WriteLine(chk.Text);
                        break;
                    case "chkSeat3":
                        writer.WriteLine(chk.Text);
                        break;
                    ...
                }
            }
        }
    }
