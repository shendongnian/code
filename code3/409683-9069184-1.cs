    class ContainingObject
    {
        private ContainedObject objContained;
    
        public int ContainingObjectID { get; set; }
        public ContainedObject Obj { get { return objContained; } }
    
        // Of course, you should include a check for if objContained is null
        public int ContainedObjectId { get { return objContained.Id; } }
        public int ContainedObjectHeight { get { return objContained.Height; } }
        public int ContainedObjectWidth { get { return objContained.Width; } }
    
    }
    class ContainedObject
    {
        public int ID { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
 
        public override ToString()
        {
            // Return whatever you want here
            return string.format("Contained object: {0}", ID);
        }
    }
