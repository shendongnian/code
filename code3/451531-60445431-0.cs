csharp
    /// <summary>
    /// This Control allows to filter the content of the RichTextBox by either manually
    /// calling <c>ApplyFilter(string)</c> with the search string or specifying a TextBox Control
    /// as a filter reference. 
    /// 
    /// Matching lines will be retained, other will be deleted.
    /// 
    /// Retains RTF formatting and when removing the filter restores the original content.
    /// 
    /// Ideal for a Debug Console.
    /// 
    /// </summary>
    public class RichFilterableTextBox : RichTextBox
    {
        private Timer timer;
        private string OriginalRTF = null;
        private TextBox _filterReference;
        private int _interval = 2000;
        public TextBox FilterReference
        {
            get => _filterReference;
            set
            {
                //if we had already a filter reference
                if (_filterReference != null)
                {
                    //we should remove the event
                    _filterReference.TextChanged -= FilterChanged;
                }
                _filterReference = value;
                //if our new filter reference is not null we need to register our event
                if (_filterReference != null)
                    _filterReference.TextChanged += FilterChanged;
            }
        }
        
        /// <summary>
        /// After the filter has been entered into the FilerReference TextBox 
        /// this will auto apply the filter once the interval has been passed.
        /// </summary>
        public int Interval
        {
            get => _interval;
            set
            {
                _interval = value;
                timer.Interval = Interval;
            }
        }
        public RichFilterableTextBox()
        {
            timer = new Timer();
            timer.Interval = Interval;
            timer.Tick += TimerIntervalTrigger;
        }
       
        public void SetFilterControl(TextBox textbox)
        {
            this.FilterReference = textbox;
        }
        
        public void ApplyFilter(string searchstring)
        {
            int startIndex = 0;
            int offset = 0;
            //check each line
            foreach (var line in this.Lines)
            {
                offset = 0;
                SelectionStart = startIndex + offset;
                SelectionLength = line.Length + 1;
                //if our line contains our search string/filter
                if (line.Contains(searchstring))
                {
                    //we apply an offset based on the line length
                    offset = line.Length;
                }
                else
                {
                    //otherwise delete the line
                    SelectedText = "";
                }
                //move the start index forward based on the current selected text
                startIndex += this.SelectedText.Length;
            }
        }
        private void FilterChanged(object sender, EventArgs e)
        {
            //take snapshot of original
            if (OriginalRTF == null)
            {
                OriginalRTF = this.Rtf;
            }
            else
            {
                //restore original
                Rtf = OriginalRTF;
                OriginalRTF = null;
            }
            timer.Stop();
            timer.Start();
        }
        private void TimerIntervalTrigger(object sender, EventArgs e)
        {
            //stop the timer to avoid multiple triggers
            timer.Stop();
            //apply the filter
            ApplyFilter(FilterReference.Text);
        }
        protected override void Dispose(bool disposing)
        {
            timer.Stop();
            timer.Dispose();
            base.Dispose(disposing);
        }
    }
This control can be either used standalone and be filter by calling the method
`ApplyFilter(string searchString)` with the desired search string. Or it can be connected to a `TextBox`
where you will be able to enter the phrase in. After a set timer interval it will auto trigger the filtering.
I am using this as a Log Display during runtime where I am also applying color codes to severity and my goal was to retain the formatting as well as be able to quickly search/filter. I attached a few screenshots:
[![Debug Console Example][1]][1]
[![Filter Applied][2]][2]
There is still room for improvements and I hope this can be used as a starting code base.
  [1]: https://i.stack.imgur.com/FlNhk.jpg
  [2]: https://i.stack.imgur.com/5iylm.jpg
