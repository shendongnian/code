    [Serializable]
    public class MyClass : ISerializable
    {
        public Pen Pen;
    
        public MyClass()
        {
            this.Pen = new Pen(Brushes.Azure);
        }
    
        #region ISerializable Implemention
    
        private const string ColorField = "ColorField";
                
        private MyClass(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
    
            SerializationInfoEnumerator enumerator = info.GetEnumerator();
            bool foundColor = false;
            Color serializedColor = default(Color);
    
            while (enumerator.MoveNext())
            {
                switch (enumerator.Name)
                {
                    case ColorField:
                        foundColor = true;
                        serializedColor = (Color) enumerator.Value;
                        break;
    
                    default:
                        // Ignore anything else... forwards compatibility
                        break;
                }
            }
    
            if (!foundColor)
                throw new SerializationException("Missing Color serializable member");
    
            this.Pen = new Pen(serializedColor);
        }
    
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(ColorField, this.Pen.Color);
        }
        #endregion
    }
