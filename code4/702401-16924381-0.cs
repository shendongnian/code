    public class MyTabControl : TabControl
    {
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                for (int i = 0; i < TabCount; ++i)
                {
                    Rectangle r = GetTabRect(i);
                    if (r.Contains(e.Location) /* && it is the header that was clicked*/)
                    {
                        // Change slected index, get the page, create contextual menu
                        ContextMenu cm = new ContextMenu();
                        // Add several items to menu
                        cm.MenuItems.Add("hello");
                        cm.MenuItems.Add("world!");
                        cm.Show(this, e.Location);
                        break;
                    }
                }
            }
            base.OnMouseUp(e);
        }
    }
