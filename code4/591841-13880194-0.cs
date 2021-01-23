    class SomeClass
    {
        static int m_Counter = 0;
        static Person[] m_Arr = new Person[] { };
        public void Add(Person p)
        {
            if (p == null)
                Console.WriteLine("Error, param can't be null");
            if (m_Arr.Length <= m_Counter)
            {
                Array.Resize(ref m_Arr, m_Arr.Length + 10);
            }
            m_Arr[m_Counter++] = p;
        }  
    }
