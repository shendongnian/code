        /// <summary>
        /// This function creates an indented format of HTML with new lines for all elements and text.  Errors result in the original text being returned.
        /// </summary>
        private static string FormatHtml(string content)
        {
            string original = content; 
            string open = "<";
            string slash = "/";
            string close = ">";
            int depth = 0; // the indentation
            int adjustment = 0; //adjustment to depth, done after writing text
            int o = 0; // open      <   index of this character
            int c = 0; // close     >   index of this character
            int s = 0; // slash     /   index of this character
            int n = 0; // next      where to start looking for characters in the next iteration
            int b = 0; // begin     resolved start of usable text
            int e = 0; // end       resolved   end of usable test
            string snippet;
            try
            {
                using (StringWriter writer = new StringWriter())
                {
                    while (b > -1 && n > -1)
                    {
                        o = content.IndexOf(open, n);
                        s = content.IndexOf(slash, n);
                        c = content.IndexOf(close, n);
                        adjustment = 0;
                        b = n; // begin where we left off in the last iteration
                        if (o > -1 && o < c && o == n)
                        {
                            // starts with "<tag>text"
                            e = c; // end at the next closing tag
                            adjustment = 2; //for after this node
                        }
                        else
                        {
                            // starts with "text<tag>"
                            e = o - 1; // end at the next opening tag
                        }
                        if (b == o && b + 1 == s) // ?Is the 2nd character a slash, this the a closing tag: </div>
                        {
                            depth -= 2;//adjust immediately, not afterward ...for closing tag
                            adjustment = 0;
                        }
                        if ((s + 1) == c && c == e) // don't adjust depth for singletons:  <br/>
                        {
                            adjustment = 0;
                        }
                        //string traceStart = content.Substring(0, b);
                        int length = (e - b + 1);
                        if (length < 0)
                        {
                            snippet = content.Substring(b); // happens on the final iteration
                        }
                        else
                        {
                            snippet = content.Substring(b, (e - b + 1));
                        }
                        //string traceEnd = content.Substring(b);
                        if (snippet == "<br>" || snippet == "<hr>") // don't adjust depth for singletons which lack slashes: <br>
                        {
                            adjustment = 0; 
                        }
                        //Write the text
                        if (!string.IsNullOrEmpty(snippet.Trim()))
                        {
                            //Debug.WriteLine(snippet);
                            writer.Write(Environment.NewLine);
                            if (depth > 0) writer.Write(new String(' ', depth)); // add the indentation 
                            writer.Write(snippet); 
                        }
                        depth += adjustment; //adjust for the next line which is likely nested
                        n = e + 1; // the next iteration start at the end of this one.
                    }
                    return writer.ToString();
                }
            }
            catch (Exception ex)
            {
                Log("Unable to format html. " + ex.Message);
                return original;
            }
        }
