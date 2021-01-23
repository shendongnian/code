    public class CheckedListBoxColorable : CheckedListBox
    {
        /// <summary>
        /// Controls the forecolors of the objects in the Items collection.
        /// If the item is not represented, it will have the default forecolor.
        /// </summary>
        public Dictionary<object, Color> Colors { get; set; }
        public CheckedListBoxColorable()
        {
            this.DoubleBuffered = true; //prevent flicker, not sure if this is necessary.
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            //Default forecolor
            Color foreColor = e.ForeColor;
            //Item to be drawn
            object item = null;
            if (e.Index >= 0) //If index is -1, no customization is necessary
            {
                //Find the item to be drawn
                if (this.Items.Count > e.Index) item = this.Items[e.Index];
                //If the item was found and we have a color for it, get the custom forecolor
                if (item != null && this.Colors != null && this.Colors.ContainsKey(item))
                {
                    foreColor = this.Colors[item];
                }
            }
            // Copy the original event args, just tweaking the forecolor.
            var tweakedEventArgs = new DrawItemEventArgs(
                e.Graphics,
                e.Font,
                e.Bounds,
                e.Index,
                e.State,
                foreColor,
                e.BackColor);
            // Call the original OnDrawItem, but supply the tweaked color.
            base.OnDrawItem(tweakedEventArgs);
        }
    }
