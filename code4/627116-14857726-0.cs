            Stack st = new Stack();
            st.Push("joginder");
            st.Push("singh");
            st.Push("banger");
            st.Push("Kaithal");
            st.Push(1);
            st.Push(1.0);
            foreach (var name in st.OfType<string>())
            {
                Console.WriteLine(name);
            }
