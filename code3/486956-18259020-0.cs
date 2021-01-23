		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Processes up key when a grid cell is in the edit mode. This overrides the default
		/// behavior in a grid cell when it's being edited so using the up arrow will move the
		/// IP up one line rather than moving to the previous row.
		/// </summary>
		/// ------------------------------------------------------------------------------------
		protected virtual bool ProcessUpKey(TextBox txtBox)
		{
			// Don't override the default behavior if all the text is selected or not multi-line.
			if (txtBox.SelectedText == txtBox.Text || !txtBox.Multiline)
				return false;
			int selectionPosition = txtBox.SelectionStart;
			// Getting the position after the very last character doesn't work.
			if (selectionPosition == txtBox.Text.Length && selectionPosition > 0)
				selectionPosition--;
			Point pt = txtBox.GetPositionFromCharIndex(selectionPosition);
			
			if (pt.Y == 0)
				return false;
			
			pt.Y -= TextRenderer.MeasureText("x", txtBox.Font).Height;
			txtBox.SelectionStart = txtBox.GetCharIndexFromPosition(pt);
			return true;
		}
		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Processes down key when a grid cell is in the edit mode. This overrides the default
		/// behavior in a grid cell when it's being edited so using the down arrow will move the
		/// IP down one line rather than moving to the next row.
		/// </summary>
		/// ------------------------------------------------------------------------------------
		protected virtual bool ProcessDownKey(TextBox txtBox)
		{
			// Don't override the default behavior if all the text is selected or not multi-line.
			if (txtBox.SelectedText == txtBox.Text || !txtBox.Multiline)
				return false;
			int chrIndex = txtBox.SelectionStart;
			Point pt = txtBox.GetPositionFromCharIndex(chrIndex);
			pt.Y += TextRenderer.MeasureText("x", txtBox.Font).Height;
			var proposedNewSelection = txtBox.GetCharIndexFromPosition(pt);
			if (proposedNewSelection <= chrIndex)
				return false; // Don't let "down" take you *up*.
			txtBox.SelectionStart = proposedNewSelection;
			return true;
		}
