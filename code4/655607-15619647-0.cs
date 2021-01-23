    // assumes you have NUM_KEYS piano keys / PictureBoxes
    Color[] pianoKeyColors = new Color[NUM_KEYS];
    // fill the pianoKeyColors array with the colors you want,
    // perhaps alternating white-black-white- ...
    // you may want to do that in the constructor for your Form
    // you should also store the PictureBox-es in an array, so you can easily
    // reference the one you want
    private void comboBox_selectNote_SelectedIndexChanged(object sender, EventArgs e)
    {
        // reset all PictureBox-es to the original colors
        for (int key = 0; key < NUM_KEYS; key++)
            pianoKeys[key].BackColor = pianoKeyColors[key];
        // and then only set the BackColor to Red of keys in the chord
        switch (comboBox_selectNode.SelectedIndex)
        {
            case 0: // C chord
                pianoKeys[KEY_C1].BackColor = Color.Red;
                pianoKeys[KEY_E1].BackColor = Color.Red;
                pianoKeys[KEY_G1].BackColor = Color.Red
                break;
            ... and the other cases ...
        }
    }
