    using System.Windows.Forms.VisualStyles;
    public partial class YourForm : Form
    {
        private static readonly VisualStyleRenderer DisabledCheckBoxRenderer;
        static YourForm()
        {
            DisabledCheckBoxRenderer = new VisualStyleRenderer(VisualStyleElement.Button.CheckBox.UncheckedDisabled);
        }
        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int checkBoxColumnIndex = this.yourCheckBoxColumn.Index;
                var checkCell = (DataGridViewCheckBoxCell)this.dataGridView[checkBoxColumnIndex, e.RowIndex];
                var bounds = this.dataGridView.GetCellDisplayRectangle(checkBoxColumnIndex , e.RowIndex, false);
                // i was drawing a disabled checkbox if i had set the cell to read only
                if (checkCell.ReadOnly)
                {
                    const int CheckBoxWidth = 16;
                    const int CheckBoxHeight = 16;
                    // not taking into consideration any cell style paddings
                    bounds.X += (bounds.Width - CheckBoxWidth) / 2;
                    bounds.Y += (bounds.Height - CheckBoxHeight) / 2;
                    bounds.Width = CheckBoxWidth;
                    bounds.Height = CheckBoxHeight;
                    if (VisualStyleRenderer.IsSupported)
                    {
                        // the typical way the checkbox will be drawn
                        DisabledCheckBoxRenderer.DrawBackground(e.Graphics, bounds);
                    }
                    else
                    {
                        // this method is only drawn if the visual styles of the application
                        // are turned off (this is for full support)
                        ControlPaint.DrawCheckBox(e.Graphics, bounds, ButtonState.Inactive);
                    }
                }
            }
        }
    }
