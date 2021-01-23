    private void TreeViewTeschd_MouseMove(object sender, MouseEventArgs e) {
        if (e.Button == MouseButtons.Left) {
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (kockak[j,i].rect.Contains(e.Location)) kockak[j,i].selected = true;
                }
            }
        }
    }
