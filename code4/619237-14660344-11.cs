        MyMetaData _myMetaData;
    
        public void PushData(MyData myData)
            {
           
                foreach (MyControl control in myData.MyControls)
                {
                 //fill table from xsd schema
           this._myMetaData.MyControls.AddMyControlsRow(control.Id,control.Name,control.Value);
        
                    
                }
    
                this._myMetaData.AcceptChanges();
            }
