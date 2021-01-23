    foreach(Control ctrl in pnl.Controls){
        if(ctrl is Checkbox){
            Checkbox chk = ctrl as Checkbox;
            if(chk.Checked)
                writer.WriteLine(chk.Text);
        }
    }
