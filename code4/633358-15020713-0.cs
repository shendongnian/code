    class CategoryProductsResult
    {
        public string Name { get; set; }
        // ...
        public override bool  Equals(object obj)
        {
            if(obj == null)return false;
            CategoryProductsResult other = obj as CategoryProductsResult;
            if(other == null)return false;
            return other.Name == this.Name;
        }
        public override int  GetHashCode()
        {
             return Name.GetHashCode();
        }
    }
