On a general syntactic note, you'd probably be better off with using statements instead of explicit calls to Dispose(), i.e.:
    using (Graphics g = Graphics.FromImage(myBitmap))
    {
       ...
    }
