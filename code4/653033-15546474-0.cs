    StackTrace st = new StackTrace();
            var fr = st.GetFrames();
            if(fr != null && fr.Any() &&fr.Count() >1)
            {
                MessageBox.Show(fr.ElementAt(1).GetMethod().Name);
            }
