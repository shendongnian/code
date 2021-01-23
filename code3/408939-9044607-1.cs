    public void Clear ()
    {
      ClearContent ();
    }
    public void ClearContent ()
    {
      output_stream.Clear ();
      content_length = -1;
    }
