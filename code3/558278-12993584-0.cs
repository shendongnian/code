    public class MyTreeNode<T>:TreeNode {
        private T data;
    
        public T Data {
            get {
                return data;
            }
            set {
                data = value;
                Text = data.ToString();
            }
        }
    }
