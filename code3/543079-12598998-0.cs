     public override void OnInputPathAttached(int inputID)
        {
            IDTSInput100 input = ComponentMetaData.InputCollection[0];
            IDTSVirtualInput100 vInput = input.GetVirtualInput();
            IDTSExternalMetadataColumnCollection100 externalColumnCollection = input.ExternalMetadataColumnCollection;
            IDTSExternalMetadataColumn100 externalColumn;                
                
            foreach (IDTSVirtualInputColumn100 vCol in vInput.VirtualInputColumnCollection)
            {            
                externalColumn = externalColumnCollection.New();
                externalColumn.Name = vCol.Name;
                externalColumn.DataType = vCol.DataType;               
            }
        }
