            public void Insert_Node(int position, string Val)
        {
            Node T = new Node(Val);
            Node temp = Head;
            int i = 0;
            if (position == i)
            {
                T.NextInstance = Head;
                Head = T;
            }
            else
            {
                while (temp != null && i < position-1)
                {
                    temp = temp.NextInstance;
                    i++;
                }
                T.NextInstance = temp.NextInstance;
                temp.NextInstance = T;
            }
            
        }
