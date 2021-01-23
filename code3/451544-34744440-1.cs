     using (StreamLineReader st = new StreamLineReader(File.OpenRead("E:\\log.txt")))
            {
                bool ok = st.GoToLine(1);
                int count= st.GetCount(0);
                string w0 = st.ReadLine();
                string w1 = st.ReadLine();
                string w2 = st.ReadLine();
                string w3 = st.ReadLine();
            }
