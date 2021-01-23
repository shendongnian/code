    class B : A 
    {
        ... extra properties ...
        public B Copy()
        {
            base.Copy();
            ... copy extra properties ...
        }
    }
