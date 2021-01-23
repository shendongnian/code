    StringBuilder sb = new StringBuilder();
    sb.Append(Environment.Newline  + "Title: " + AlbumName);
    sb.Append(Environment.Newline  + "Genre: " + AlbumGenre);
    sb.Append(Environment.Newline  + "Year : " + AlbumYear);
    sb.Append(Environment.Newline  + "Url  : " + AlbumLink);
    RichTextBox1.Text = sb.ToString();
