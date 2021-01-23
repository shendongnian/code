    public class UIControlsHelper
    {
        public static void ClearTextboxes(Page page)
        {
            GetAllControls(page)
                .Where(x => typeof(TextBox).IsAssignableFrom(x.GetType())
                .ToList()
                .ForEach(x => (TextBox)x.Text = string.Empty);
                
        }
        IEnumerable<Control> GetAllControls(Page page)
          // Same as above, but with the page parameter replaced.
        }
    }
