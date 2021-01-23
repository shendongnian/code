    PictureBox thumb = new util.PictureBox(pageNum);
    thumb.Image = doc.getThumb(pageNum);  //since we pre loaded, we won't stall the gui thread.
    thumb.SizeMode = PictureBoxSizeMode.CenterImage;
    thumb.BorderStyle = BorderStyle.FixedSingle;
    thumb.Click += new System.EventHandler(
        (thumbSend, thumbEvent) =>
        {
            selectThumb(thumb);
        }
    );
    thumb.DoubleClick += new System.EventHandler(
        (thumbSend, thumbEvent) =>
        {
            selectedDoc = thumb.getPage();
            me.Visible = false;
        }
    );
    thumbFlow.Controls.Add(thumb);
    if (selectedDoc == pageNum)
        selectThumb(thumb);
