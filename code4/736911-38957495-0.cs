    public Node ReverseRecursive(Node root)
            {
                Node temp = root;
                if (root.next == null)
                    return root;
                else
                    root = ReverseRecursive(root.next);
                temp.next = null;
                Node tail = root.next;
                if (tail == null)
                    root.next = temp;
                else
                    while (tail != null)
                    {
                        if (tail.next == null)
                        {
                            tail.next = temp;
                            break;
                        }
                        else
                            tail = tail.next;
                    }
                return root;
            }
