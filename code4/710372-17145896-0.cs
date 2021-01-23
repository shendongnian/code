    public class CustomCheckedList : CheckedListBox
    {
        public CustomCheckedList()
        {
            DisabledIndices = new List<int>();
            DoubleBuffered = true;
        }
        public List<int> DisabledIndices { get; set; }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            Size checkSize = CheckBoxRenderer.GetGlyphSize(e.Graphics, System.Windows.Forms.VisualStyles.CheckBoxState.MixedNormal);
            int d = (e.Bounds.Height - checkSize.Height) / 2;                        
            if(DisabledIndices.Contains(e.Index)) CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(d,e.Bounds.Top + d), GetItemChecked(e.Index) ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedDisabled : System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedDisabled);
        }
        protected override void OnItemCheck(ItemCheckEventArgs ice)
        {
            base.OnItemCheck(ice);
            if (DisabledIndices.Contains(ice.Index)) ice.NewValue = ice.CurrentValue;
        }
    }
    //To disable the item at index 0:
    customCheckedList.DisableIndices.Add(0);
