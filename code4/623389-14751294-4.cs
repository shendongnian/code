    private void btnTransferBottleRegenerate_Click(object sender, EventArgs e)
    {
      int[] percentages = new int[6];
      percentages[0] = int.Parse(txtTransferNotIdentified.Text);
      percentages[1] = int.Parse(txtTransferWater.Text);
      // And so on for every textbox
      Color[] colors = new Color[6];
      colors[0] = Color.Red;
      colors[1] = Color.Yellow;
      // And so on for every color
      // Finally, call the method in my example above
      DrawPercentages(percentages, colors);
    } 
