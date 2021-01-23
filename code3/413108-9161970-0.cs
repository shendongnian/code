            WebRequest wr = WebRequest.Create(@"http://127.0.0.1/Test.html");
            wr.Headers.GetType().InvokeMember("ChangeInternal", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, wr.Headers, new object[] { "Host", "www.example.com" });
            var resp = wr.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            MessageBox.Show(sr.ReadToEnd().ToString());
