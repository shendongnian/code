    class MyTransform
    {
        //wrapped transform structure
        private CGAffineTransform transform;
        //stored info about rotation
        public float Rotation { get; private set; }
        public MyTransform()
        {
            transform = CGAffineTransform.MakeIdentity();
            Rotation = 0;
        }
        public void Rotate(float angle)
        {
            //rotate the actual transform
            transform.Rotate(angle);
            //store the info about rotation
            Rotation += angle;
        }
        //lets You expose the wrapped transform more conveniently
        public static implicit operator CGAffineTransform(MyTransform mt)
        {
            return mt.transform;
        }
    }
