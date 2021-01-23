            string responseString           = "This could be json to be parsed by the extension";
            HttpListenerResponse response   = context.Response;
            response.ContentType            = "text/html";
            byte[] buffer                   = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64        = buffer.Length;
            Stream output                   = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
