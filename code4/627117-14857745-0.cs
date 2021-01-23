            Stack st = new Stack();
            st.Push("joginder");
            st.Push(1.4);
            st.Push("singh");
            st.Push("banger");
            st.Push(2.8); 
            st.Push("Kaithal");
            IEnumerable<String> strings = st.OfType<String>();  //how to work this option
            IEnumerable<double> doubles = st.OfType<double>();   
