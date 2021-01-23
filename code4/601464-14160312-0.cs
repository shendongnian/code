    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      label1.Text = textBox1.Text;
      label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      //First make the font big enough
      double fontSize = label1.Width / label1.Text.Count();
      int height = label1.Height;
      fontSize = fontSize > 0 ? (double)fontSize : 1;
      if (fontSize < (height / 2))
      {
        fontSize = (height / 2);
      }
      label1.Font = new System.Drawing.Font(label1.Font.FontFamily, (float)fontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      //then adjust the text to the label size
      while (label1.Width < System.Windows.Forms.TextRenderer.MeasureText(label1.Text,
          new Font(label1.Font.FontFamily, label1.Font.Size, label1.Font.Style)).Width ||
          label1.Height < System.Windows.Forms.TextRenderer.MeasureText(label1.Text,
          new Font(label1.Font.FontFamily, label1.Font.Size, label1.Font.Style)).Height)
      {
        label1.Font = new Font(label1.Font.FontFamily, label1.Font.Size > 1 ? label1.Font.Size - 0.5f : label1.Font.Size, label1.Font.Style);
        if (label1.ClientRectangle.Width < 3 || label1.ClientRectangle.Height < 3)
          break;
      }
    }
