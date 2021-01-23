    private void UsersGrid_Load(object sender, EventArgs e) {
        // Register the MouseClick event with the UC's surface.
        this.MouseClick += Control_MouseClick;
        // Register MouseClick with all child controls.
        RegisterMouseEvents(Controls);
    }
