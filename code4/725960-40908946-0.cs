    public class CustomCheckedListBox : CheckedListBox
    {
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Color foreColor;
            if (e.Index >= 0)
            {
                foreColor = GetItemChecked(e.Index) ? Color.Green : Color.Red;
            }
            else
            {
                foreColor = e.ForeColor;
            }
    
            // Copy the original event args, just tweaking the fore color.
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
