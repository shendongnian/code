    public void CreateInventory(CreateInventory createinventory)
        {
            try
            {
                using (FileStream fileStream = new FileStream("CreateInventory.bin", FileMode.Create, FileAccess.Write))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, createinventory);
                }
            }
            catch (Exception ex)
            {
                throw new ItemNotFoundException("Output not created - see logs", ex);
            }
        }
