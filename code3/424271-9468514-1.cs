    public interface IBinaryNode<T>
    {
        int? ID { get; }
        T Data { get; set; }
        IBinaryNode<T> RightChild { get; set; }
        IBinaryNode<T> LeftChild { get; set; }
        IEnumerable<IBinaryNode<T>> Traverse(IBinaryNode<T> current, IEnumerable<IBinaryNode<T>> recursionData);
    }
    
    public class BinaryNode<T> : IBinaryNode<T>
    {
        public int? ID{get; private set;}
        public T Data { get; set; }
        public IBinaryNode<T> RightChild { get; set; }
        public IBinaryNode<T> LeftChild { get; set; }
    
        public BinaryNode():this(default(T)){}
        public BinaryNode(T data):this(data, null){}
        public BinaryNode(T data, int? id)
        {
            Data = data;
            ID = id;
        }
    
        public IEnumerable<IBinaryNode<T>> Traverse(IBinaryNode<T> current, IEnumerable<IBinaryNode<T>> recursionData)
        {
            // no children found
            if (RightChild == null && LeftChild == null)
            {
                //correct guess BinaryNode has the needed data
                if (current.Data.Equals(Data))
                {
                    return recursionData;
                }
    
                //wrong value - try another leg
                return null;
            }
    
            //there are children
            IEnumerable<IBinaryNode<T>> left = null; //tmp left storage
            IEnumerable<IBinaryNode<T>> right = null; //tmp right storage
    
            //start with the left child
            //and travers in depth by left leg
            if (LeftChild != null)
            {
                //go in depth through the left child 
                var leftPath = new List<IBinaryNode<T>>();
    
                //add previously gathered recursionData
                leftPath.AddRange(recursionData);
    
                leftPath.Add(LeftChild);
    
                //recursion call by rigth leg
                left = LeftChild.Traverse(current, leftPath);
            }
    
            //no left children found
            //travers by right leg in depth now
            if (RightChild != null)
            {
                //go in depth through the right child 
                var rightPath = new List<IBinaryNode<T>>();
    
                //add previously gathered recursionData
                rightPath.AddRange(recursionData);
    
                //add current value 
                rightPath.Add(RightChild);
    
                //recursion call by rigth leg
                right = RightChild.Traverse(current, rightPath);
            }
    
            //return collected value of left or right
            if (left != null)
            {
                return left;
            }
    
            return right;
        }
    }
