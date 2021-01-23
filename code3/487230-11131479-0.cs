    public void Remove(int id)
            {
                InventoryItem item = context.Items.Find(id);
                context.Items.Remove(item);
                context.SaveChanges();
            }
