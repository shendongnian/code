        {
            string uriupdatestudent = string.Format("http://localhost:8000/Service/Student/{0}", textBox16.Text);
            StringBuilder sb = new StringBuilder();
            sb.Append("<Student>");
            sb.AppendLine("<FirstName>" + this.textBox17.Text + "</FirstName>");
            sb.AppendLine("<LastName>" + this.textBox18.Text + "</LastName>");
            sb.AppendLine("</Student>");
            string NewStudent = sb.ToString();
            byte[] arr = Encoding.UTF8.GetBytes(NewStudent);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uriupdatestudent);
            req.Method = "PUT";
            req.ContentType = "application/xml";
            req.ContentLength = arr.Length;
            Stream reqStrm = req.GetRequestStream();
            reqStrm.Write(arr, 0, arr.Length);
            reqStrm.Close();
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            MessageBox.Show(resp.StatusDescription);
            reqStrm.Close();
            resp.Close();
        }
