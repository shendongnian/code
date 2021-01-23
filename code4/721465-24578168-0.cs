            int machineUint = 0; 
            try
            {
                machineUint = BitConverter.ToUInt16(bytes, 12);
            }
            catch (IndexOutOfRangeException indexer)
            {
               machineUint = 0;
            }
            catch (Exception ex)
            {
               machineUint = 0;
            }
    
