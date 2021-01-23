        public void BuildHeader(string contentType, string filename)
        {
            if ((contentType == null) ||
                (contentType.Length == 0))
            {
                contentType = "application/octet-stream";
            }
            // Create the boundary string for the POST message header
            string boundary = "----------" + DateTime.Now.Ticks.ToString("x");
            // Build up the POST message header
            StringBuilder sb = new StringBuilder();
            // The specific format used can be found in the HTTP protocol specs.
            // The 'name' variable indicates the field-name, and the last variable
            // added to the string before another boundary is the value for that field.
            sb.Append("--");
            sb.Append(boundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"");
            sb.Append("path");
            sb.Append("\"");
            sb.Append("\r\n\r\n");
            sb.Append(fileName);
            sb.Append("--");
            sb.Append(boundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"");
            sb.Append("contents");
            sb.Append("\"; fileName=\"");
            sb.Append("abc");
            sb.Append("\"");
            sb.Append("\r\n");
            sb.Append("Content-Type: ");
            sb.Append(contentType);
            sb.Append("\r\n");
            sb.Append("\r\n");
            
            using (Stream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                // Add the file contents to the POST message
                byte[] buffer = new Byte[checked((uint)Math.Min(4096, (int)fileStream.Length))];
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    sb.Append(ASCIIEncoding.ASCII.GetString(buffer));
                }
                // Get the byte array of the POST message, and its length
                string totalContents = sb.ToString();
                byte[] totalUpload = Encoding.UTF8.GetBytes(totalContents);
                int length = totalUpload.Length;
            }
        }
