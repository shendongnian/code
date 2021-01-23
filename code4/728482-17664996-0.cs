    // find the right row
    if (lines[i].ToLower().StartsWith(rowID))
    {
      // we have to know which delim was used to split the string since this will be 
      // used when stitching back the string together.
      for (int delim = 0; delim < delims.Length; delim++)
      {
       // we split the line into an array and then use the array index as our column index
       split_line = lines[i].Trim().Split(delims[delim]);
       // we found the right delim
       if (split_line.Length > 1)
       {
         delim_used = delims[delim];
         break;
       }
      }
    }
