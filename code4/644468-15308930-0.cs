    private void button1_Click(object sender, EventArgs e)
            {
                
                DataFormats.Format myFormat = DataFormats.GetFormat("myFormat");
                GraphicsPathWrap myObj = new GraphicsPathWrap ();
    
                DataObject obj = new DataObject();
                obj.SetData(myFormat.Name, myObj);
                Clipboard.SetDataObject(obj);
    
                GraphicsPathWrap objData = Clipboard.GetDataObject().GetData(myFormat.Name);
            }
    
            // Creates a new type.
            [Serializable]  // Mandatory for you
            public struct GraphicsPathWrap : ISerializable
            {
                private static string myValue = "This is the value of the class";               
               
    
                // Creates a property to retrieve or set the value. 
                public string MyObjectValue
                {
                    get
                    {
                        return myValue;
                    }
                    set
                    {
                        myValue = value;
                    }
                }
    
                #region ISerializable Members
    
                public void GetObjectData(SerializationInfo info, StreamingContext context)
                {
                    throw new NotImplementedException();
                }
    
                #endregion
            }
