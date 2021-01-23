        private void Slider_Scroll(object sender, EventArgs e)
        {
            TrackBar sourceSlider;
            TextBox sourceText;
            TrackBar targetSlider;
            TextBox targetText;
            sourceSlider = sender == trackBar1 ? trackBar1 : trackBar2;
            targetSlider = sender == trackBar1 ? trackBar2 : trackBar1;
            sourceText = sender == trackBar1 ? textBox1 : textBox2;
            targetText = sender == trackBar1 ? textBox2 : textBox1;
            sourceText.Text = Convert.ToString(sourceSlider.Value);
            if (syncOption.Checked)
            {
                targetSlider.Value = sourceSlider.Value;
                targetText.Text = Convert.ToString(targetSlider.Value);
            }
        }
