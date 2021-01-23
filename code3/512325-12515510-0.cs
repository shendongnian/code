        private void imageContainer_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                imageContainer_MouseWheelScrollUp(sender, e);
            }
            else if (e.Delta < 0)
            {
                imageContainer_MouseWheelScrollDown(sender, e);
            }
            prevVScrollVal = imageContainer.VerticalScroll.Value;
        }
        private void imageContainer_MouseWheelScrollUp(object sender, MouseEventArgs e)
        {
            if (imageContainer.VerticalScroll.Value == 0 && 
                prevVScrollVal == 0 && 
                current > 1)
            {
                setPagePrev();
            }
        }
        private void imageContainer_MouseWheelScrollDown(object sender, MouseEventArgs e)
        {
            
            if (imageContainer.VerticalScroll.Value == prevVScrollVal && 
                    current < endPage)
            {
                setPageNext();
            }
        }
        /// <summary>
        /// Sets the page to the Next
        /// </summary>
        private void setPageNext()
        {
            setPage(current + 1);
        }
        /// <summary>
        /// Sets the page to the Previous
        /// </summary>
        private void setPagePrev()
        {
            setPage(current - 1);
            prevVScrollVal = imageContainer.VerticalScroll.Maximum;
            imageContainer.VerticalScroll.Value = imageContainer.VerticalScroll.Maximum;
            imageContainer.PerformLayout();
        }
        /// <summary>
        /// Sets the page to be viewed
        /// </summary>
        /// <param name="page">page to be viewed</param>
        public void setPage(int page)
        {  ....  }
