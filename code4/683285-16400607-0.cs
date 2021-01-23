	if (item.IsSet)
	{
		DialogResult isComplete = MessageBox.Show("Complete set?", "complete set?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (isComplete == DialogResult.No)
			// Break out
	}
	if(item.IsNew)
	{
		DialogResult goodQuality = MessageBox.Show("Is the quality good", "quality", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
		if (goodQuality == DialogResult.No)
			//not accepted (break)
	}
	//if reached here, accepted
