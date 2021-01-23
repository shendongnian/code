    private void resizeMe() 
    {
        this.BeginInvoke((Action)() => {
            splitContainer.Height = tableBorder.Height;
            splitContainer.Width = tableBorder.Width;
        }
    }
