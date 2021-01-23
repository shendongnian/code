    //This is refrencing the Tag Reader
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            ID3v1TagReader tr = new ID3v1TagReader();
            ID3v1Tag ti = new ID3v1Tag();
            //This is telling the tag reader in which field the information must go
            ti = tr.ReadID3v1Tag(openFileDialog1.FileName);
            trackTextBox.Text = ti.TrackName;
            artistTextBox.Text = ti.ArtistsName;
            albumTextBox.Text = ti.AlbumName;
            comboBox1.Text = ti.Genres;
            locationTextBox.Text = openFileDialog1.FileName;
            yearTextBox.Text = ti.Year;
        }
