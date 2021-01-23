    foreach(Control c in ButtonPanel.Controls){
        if(c.GetType()==typeof(Button)){
            Button btn = (Button)c;
            btn.BackColor = Color.DarkGreen;
        }
    }
