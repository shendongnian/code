    List<PictureBox> pbs = new List<PictureBox>();
    foreach(Control c in this.Controls) if( c is PictureBox ) pbs.Add( (PictureBox)c );
    
    private void MakeMoleVisible(Int32 mole) {
        pbs[ mole ] = // whatever
    }
