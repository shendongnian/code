    public class LinkerIncludePlease
    {
        private void IncludeClicked(UIButton button)
        {
            button.Clicked += (s, e) => { };
        }
        private void IncludeEnabled(UIButton button)
        {
            button.Enabled = !button.Enabled;
        }
        private void IncludeText(UILabel label)
        {
            label.Text = label.Text + "test";
        }
    }
