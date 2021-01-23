    public static MemoryStream ImportantStreamManipulator()
    {
       // Probably add a comment here stating that the lack of using statements
       // is deliberate.
       MemoryStream stream = new MemoryStream();
    
       StreamWriter writer = new StreamWriter(stream);
       // Code that writes stuff to the memorystream via streamwriter
       writer.Flush();
       stream.Position = 0;
       return stream;
    }
