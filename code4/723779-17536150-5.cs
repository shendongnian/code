    public class MyNewDoubleStringDictionary<T> : IMyDoubleStringDictionaryBase<T>
    {
        private class Node<T>
        {
            public Node<T> Next;
            public string Key1,Key2;
            public T Value;
        }
        private const int ARRAY_SIZE = 1024;
        private Node<T>[] _internalCollection = new Node<T>[ARRAY_SIZE];
        private int GetIndex(string key1, string key2)
        {
            const int key1mask = 0x0F0F0F0F;
            const int key2mask = 0xF0F0F0F0;
            var key1 = key1mask & key1.GetHashCode();
            var key2 = key2mask & key2.GetHashCode();
            var result = ((key1 | key2) & 0x7FFFFFFF)% ARRAY_SIZE;
            return result;
        }
 
        private Node<T> GetOrMakeNode(string key1,string key2)
        {
           int index = GetIndex(key1,key2);
           Node<T> currNode=_internalCollection[index];
           
           if(currNode == null)
           {
               _internalCollection[index] = currNode = new Node<T>();
            }
            else
           {
               while(!(currNode.Key1.Equals(key1)
                        &&currNode.Key2.Equals(key2))
                   if(currNode.Next!=null)
                   {
                      currNode = currNode.Next;
                   }
                   else
                   {
                     currNode.Next = new Node<T>();
                     currNode = currNode.Next;
                   }
           }
           if(currNode.Key1 == null || currNode.Key2 == null)
           {
               currNode.Key1 = key1;
               currNode.Key2 = key2;
           }
           return currNode;
        }
        public this[string index1, string index2]
        {
            get
            {
               var node = GetOrMakeNode(index1,index2);
               return node.Value;
            }
            set
            {
               var node = GetOrMakeNode(index1,index2);
               node.Value = value;
            }
        }
    }
